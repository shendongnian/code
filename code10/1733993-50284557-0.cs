    private void webview_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {
        if (args.Uri.ToString() == "certain_file.html")
        {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        else
        {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
