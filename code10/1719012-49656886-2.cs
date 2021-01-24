    public CounterIconViewModel(IMessenger messenger)
    {
        ConfigureReportPathCommand = new RelayCommand(() => 
        {
            ...
            messenger.Send(...);
        });
    }
