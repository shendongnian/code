    public MonitoringTabsViewModel(string idCode, string description)
    {
        IdCode = idCode;
        Description = description;
        LoadSensors(idCode);
        MessagingCenter.Subscribe<MonitoringView>(this, "OnAppearing", (sender) =>
        {
            InPage = true;
            Device.StartTimer(TimeSpan.FromSeconds(5), TimerCallBack);
    
        });
        MessagingCenter.Subscribe<MonitoringView>(this, "OnDisAppearing", (sender) =>
        {
            InPage = false;
        });
    }
