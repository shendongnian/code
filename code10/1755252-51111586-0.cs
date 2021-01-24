	WebViewSource webViewSource;
	if (InternetConnected)
	{
		webViewSource = new UrlWebViewSource { Url = "https://stackoverflow.com" };
	}
	else
	{
		string baseUrl = cacheDir;
		webViewSource = new HtmlWebViewSource { BaseUrl = baseUrl, Html = cachedHtml };
	}
	webView.Source = webViewSource;
