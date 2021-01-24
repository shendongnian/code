    public class AppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IAuthenticationService _authService;
        public AppStart(
            IMvxApplication application,
            IMvxNavigationService navigationService,
            IAuthenticationService authService)
            : base(application, navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            var isUserLoggedIn = _authService.IsUserLoggedIn();
            if (isUserLoggedIn)
            {
                await _navigationService.Navigate<NavControllerViewModel>();
            }
            else
            {
                await _navigationService.Navigate<LoginViewModel>();
            }
        }
    }
