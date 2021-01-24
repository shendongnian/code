    public class LoginViewModel : ReactiveObject
    {
        public LoginViewModel()
        {
            var canLogin = this.WhenAnyValue(
                x => x.UserName,
                x => x.Password,
                (userName, password) => !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password));
            LoginCommand = ReactiveCommand.CreateFromObservable(
                LoginAsync, // A method that returns IObservable<Unit>
                canLogin);
        }
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }
    }
...
    public partial class LogInViewController : ReactiveViewController<LoginViewModel>
    {      
        UITapGestureRecognizer SingUpGesture;
        public LogInViewController (IntPtr handle) : base (handle)
        {
            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.UserName, v => v.userNameTextField.Text));
                d(this.Bind(ViewModel, vm => vm.Password, v => v.passwordTextField.Text));
                d(this.BindCommand(ViewModel, vm => vm.LoginCommand, v => vm.logInButton));
            });
        }
    }
