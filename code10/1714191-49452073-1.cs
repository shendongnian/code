    class WebViewClientClass : WebViewClient
    {    
        private ProgressBarHandler handler;
        public WebViewClientClass(ProgressBarHandler handler){
            this.handler = handler;
        }
       
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            Log.Info("101028", "loading finised");
            handler.hideProgress();
        }
    }
