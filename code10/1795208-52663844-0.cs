                    var myFilter = new HttpBaseProtocolFilter();
                    myFilter.AllowAutoRedirect = true;
                    myFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.Default;
                    myFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.Default;
                    var cookieManager = myFilter.CookieManager;
                    var request = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, new Uri("http://example.com/index.php"));
                    IHttpContent content = new HttpFormUrlEncodedContent(new [] { (new KeyValuePair<string, string>("param", myParam)) });
                    request.Content = content;
                    using (var client = new Windows.Web.Http.HttpClient())
                    {
                        var result = await client.SendRequestAsync(request);
                        result.EnsureSuccessStatusCode();
                        var resultContent = await result.Content.ReadAsStringAsync();
                    }
        
                    webView.Settings.IsJavaScriptEnabled = true;
                    webView.Settings.IsIndexedDBEnabled = true;
        
                    webView.Navigate(new Uri("http://example.com/index.php"));
