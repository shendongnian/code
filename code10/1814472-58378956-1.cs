    public MainVM()
    {
        //other code...
        Task.Delay(100).ContinueWith(_ => UpdatePreferences());
    }
    public void UpdatePreferences()
    {
        //other code..
        CollectionViewSource.GetDefaultView(Data.Customers).Refresh();
    }
