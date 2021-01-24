    class LogModel:INotifyPropertyChanged
    {
        public ObservableCollection<string> Logging { get; set; } = new ObservableCollection<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        public void Add(string text)
        {            
            Logging.Add(text);
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs("Logging"));
        }
        public void BulkLoad(string[] texts)
        {
            Logging = new ObservableCollection<string>(texts);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Logging"));
        }
    }
