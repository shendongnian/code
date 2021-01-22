    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        string var;
        if (NavigationContext.QueryString.TryGetValue("version", out var))
        {
            ...
        }
    }
