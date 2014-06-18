using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMHobby.ViewModel
{
    public class HobbyLijstVM : ViewModelBase
    {
        private ObservableCollection<HobbyDetailVM> loadedHobbies = new ObservableCollection<HobbyDetailVM>();

        public HobbyLijstVM(Model.HobbyLijst nHobbyLijst)
        {
            if (nHobbyLijst != null)
            {
                foreach (var h in nHobbyLijst.Hobbies)
                {
                    loadedHobbies.Add(new HobbyDetailVM(h));
                }
            }
        }

        private ObservableCollection<HobbyDetailVM> hobbies;

        public ObservableCollection<HobbyDetailVM> Hobbies
        {
            get
            {
                return hobbies;
            }
            set
            {
                hobbies = value;
                RaisePropertyChanged("Hobbies");
            }
        }

        private HobbyDetailVM selectedHobby;

        public HobbyDetailVM SelectedHobby
        {
            get
            {
                return selectedHobby;
            }
            set
            {
                selectedHobby = value;
                RaisePropertyChanged("SelectedHobby");
            }
        }

        public RelayCommand LoadHobbiesCommand
        {
            get
            {
                return new RelayCommand(LoadHobbies);
            }
        }

        private void LoadHobbies()
        {
            Hobbies = loadedHobbies;
        }
    }
}
