    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Thread.Sleep(5000);        
        ProgressBar.Visibility = Visibility.Collapsed;
    }
