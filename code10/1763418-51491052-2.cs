    WebView webView = new WebView(this);
    SetContentView(webView);
    webView.Settings.JavaScriptEnabled = true;
    webView.AddJavascriptInterface(new MyJSInterface(this), "deviceInterface");
    webView.LoadData("PATH TO OSM PAGE THAT HOSTED IN SERVER", "text/html", null);
