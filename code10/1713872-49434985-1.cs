    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        await Task.Delay(5000);
        ProgressBar.Visibility = Visibility.Collapsed;
    }
