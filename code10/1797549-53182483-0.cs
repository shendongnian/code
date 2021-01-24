        private int MainViewId;
        private int SecondViewId;
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += MainPage_CloseRequested;
        }
        private async void MainPage_CloseRequested(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
        {   
            // Switch to Secondary window, Hide main window                          
            await ApplicationViewSwitcher.SwitchAsync(
                    SecondViewId,
                    MainViewId,
                    ApplicationViewSwitchingOptions.ConsolidateViews);
            
            // The close was handled, don't do anything else
            e.Handled = true;
        }
        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainViewId = ApplicationView.GetForCurrentView().Id;
            var newCoreApplicationView = CoreApplication.CreateNewView();             
            await newCoreApplicationView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                SecondViewId = ApplicationView.GetForCurrentView().Id;
                Window SecondWindow = Window.Current;
                var frame = new Frame();
                frame.Navigate(typeof(Assets.SecondWindow));
                SecondWindow.Content = frame;
                SecondWindow.Activate();
            });
            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(SecondViewId, ViewSizePreference.Default);
        }
