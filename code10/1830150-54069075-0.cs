    var webview = FindViewById<WebView>(Resource.Id.webView1);
    WebSettings settings = webview.Settings;
    settings.JavaScriptEnabled = true;
    // load the javascript interface method to call the foreground method
    webView.AddJavascriptInterface(new MyJSInterface(this), "CSharp");
    webview.SetWebViewClient(new WebViewClient());
