    public class WebPage : ContentPage
    {
        Xamarin.Forms.Webview browser;
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            if (browser.CanGoBack)
            {
                browser.GoBack();
                return true;
            }
            else
            {
                base.OnBackButtonPressed();
                return true;
            }
        }
        public WebPage()
        {
            browser = new Xamarin.Forms.WebView();
            browser.Source = "https://myurl.com";
            Content = browser;
        }
    }
