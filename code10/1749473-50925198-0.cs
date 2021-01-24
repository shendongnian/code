    public sealed partial class WebViewPage : Page
    {
        public WebViewPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += WebViewPage_BackRequested;
            var site = (e.Parameter as Dictionary<string, string>)["site"];
            WebViewer.Navigate(new Uri(site));
        }
        private void WebViewPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            //always try to go back within the WebView first, then try the frame!
            if (this.Frame.CanGoBack)
            {
                if (WebViewer.CanGoBack)
                {
                    WebViewer.GoBack();
                    e.Handled = true;
                    
                }
                else
                {
                    WebViewer.NavigateToString("<html>Unloaded.</html>");
                    WebViewer.NavigateToString("");
                    var source = WebViewer.Source; // is cleared to null
                    Frame.GoBack();
                    e.Handled = true;
                }
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= WebViewPage_BackRequested;
        }
    }
