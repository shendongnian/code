    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
    
        }
    
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= SecondPage_BackRequested;
        }
    
        private void SecondPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("borderOut", MainBorder);
            Frame?.GoBack();
            e.Handled = true;
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += SecondPage_BackRequested;
    
            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("borderIn");
            animation?.TryStart(MainBorder);
        }
    }
