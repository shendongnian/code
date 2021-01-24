    ...
    webview.Navigating+=WebView_Navigating
    ...
    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
          string url = evt.Url;
    
          if (url.ToLower().Contains("..MyOnclickMethod"))
          {
             //do your code here...
                evt.Cancel = true;
          }
    }
