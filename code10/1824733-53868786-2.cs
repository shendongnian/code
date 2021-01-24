    public class LoginPageViewModel : ViewModelBase {
        private readonly IDialogService dialog;
        
        public LoginPageViewModel(IDialogService dialog) {
           LogoutCommand = new RelayCommand(LogoutExecution);
        }
        
        public ICommand LogoutCommand { get; private set; }
        
        void LogoutExecution() {
           logOut += onLogOut;
           logOut(this, EventArgs.Empty);
        }
        
        private event EventHdnalder logOut = delegate { };
        
        private async void onLogOut(object sender, EventArgs args) {
            logOut -= onLogOut;
            var result = await dialog.DisplayAlert("Alert!","Are you sure you want to logout?", "Yes", "No");
            if (result) {
              //Code Execution
              await LogOut();
           }
        }
        
        //...
    }
    
