     protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (null != webView)
            {
                webView = null;
            }
        }
