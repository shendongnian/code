            public override void OnPageFinished(WebView view, string url)
            {              
                var cookieHeader = CookieManager.Instance.GetCookie(view.Url);
                base.OnPageFinished(view, url);
            }
            public override void OnReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
            {
                handler.Proceed();
            }
