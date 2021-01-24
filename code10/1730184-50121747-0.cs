    public ObservableCollection<LogData> LogList
    {
        get
        {
            if (logList == null)
            {
                logList = new ObservableCollection<LogData>();
            }
            return logList;
        }
        set
        {
            if(LogList.Count < 1001)
            {
              logList = value;
              OnPropertyChanged("LogList");
            }
        }
    }
