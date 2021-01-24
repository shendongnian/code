    public class LoginPageViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator { get; }
        private IAuthService _authService { get; }
        public LoginPageViewModel(IEventAggregator eventAggregator, IAuthService authService)
        {
            _authService = authService;
            _eventAggregator = eventAggregator;
        }
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public DelegateCommand LoginCommand { get; }
        private async void OnLoginCommandExecuted()
        {
            var jwt = await _authService.LoginAsync(UserName, Password);
            _eventAggregator.GetEvent<UserAuthenticatedEvent>().Publish(jwt);
        }
    }
    public class App : PrismApplication
    {
        protected override async void OnInitialized()
        {
            var ea = Container.Resolve<IEventAggregator>();
            ea.GetEvent<UserAuthenticatedEvent>().Subscribe(OnUserAuthencticated);
            await NavigationService.NavigateAsync("LoginPage");
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthenticationModule>();
        }
        private async void OnUserAuthencticated(string jwt)
        {
            // store jwt for use
            await NavigationService.NavigateAsync("/MainPage");
        }
    }
