    var cookies = FullWebBrowserCookie.GetCookieInternal(webBrowser1.Url, false);
    WebClient wc = new WebClient();
    wc.Headers.Add("Cookie: " + cookies);
	wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    byte[] result = wc.UploadData("<URL>", "POST", System.Text.Encoding.UTF8.GetBytes(postData));
			
