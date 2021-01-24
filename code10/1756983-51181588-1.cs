    public class AssignedViewModel : BaseViewModel, INavigatingAware {
        public AssignedViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base(navigationService, dialogService) {
            //Subscribe to event
            this.navigatedTo += onNavigated;
        }
    
        public void OnNavigatingTo(NavigationParameters parameters) {
            navigatedTo(this, EventArgs.Empty); //Raise event
        }
    
        private event EventHandler navigatedTo = degelate { };
        private async void onNavigated(object sender, EventArgs args) {
            try {
                Models.Vehicle Current = await App.SettingsInDb.CurrentVehicle();
                CommonProperty = Current.NameToShow; //On UI Thread
            } catch (Exception e) {
                App.LogToDb.Error(e);
            }
        }
    }
