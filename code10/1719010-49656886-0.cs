    public CounterIconViewModel(IMessenger messenger)
    {
        void ConfigureReportPath()
        {
            ...
            messenger.Send(...);
        }
    
        ConfigureReportPathCommand = new RelayCommand(ConfigureReportPath);
    }
