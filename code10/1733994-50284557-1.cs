    private void WebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {
        if (args.Uri.LocalPath == "/HTMLPage1.html")
        {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        else
        {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
