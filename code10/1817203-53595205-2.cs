    public class Tab2ViewModel : MvxNavigationViewModel
    {
        public Tab2ViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            ShowRootViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Navigate<RootViewModel>());
            CloseViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Close(this));
        }
        public IMvxAsyncCommand ShowRootViewModelCommand { get; private set; }
        public IMvxAsyncCommand CloseViewModelCommand { get; private set; }
    }
