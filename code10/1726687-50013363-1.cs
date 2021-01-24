    public class MyWebViewAndroidRenderer : WebViewRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
                
            Control.SetWebViewClient(new ExtendedWebViewClient(Element as AutoWebView));
               
        }
    
        class ExtendedWebViewClient : Android.Webkit.WebViewClient
        {
            AutoWebView xwebView;
            public ExtendedWebViewClient(AutoWebView webView)
            {
                xwebView = webView;
            }
    
            async public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                if (xwebView != null)
                {
                    int i = 10;
                    while (view.ContentHeight == 0 && i-- > 0) // wait here till content is rendered
                        await System.Threading.Tasks.Task.Delay(100);
                    xwebView.HeightRequest = view.ContentHeight;
                    // Here use parent to find the ViewCell, you can adjust the number of parents depending on your XAML
                    (xwebView.Parent.Parent as ViewCell).ForceUpdateSize();
                }
                   
                base.OnPageFinished(view, url);
            }
        }
    }
