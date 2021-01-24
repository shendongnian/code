    public MainPage()
    {
        this.InitializeComponent();        
        urls = new List<Uri>();
        waitForNavComplete = new AutoResetEvent(false);
        urls.Add(...); 
    }
    List<Uri> urls;
    AutoResetEvent waitForNavComplete;
    private async void btnnavigate_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            mywebview.Navigate(urls[i]);
            await Task.Run(() => { waitForNavComplete.WaitOne(); });
        }
    }
    private void mywebview_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine(args.Uri.ToString());
        waitForNavComplete.Set();
    }
