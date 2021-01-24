    class LogModel:INotifyPropertyChanged
    {
        public List<string> Logging { get; } = new List<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        public void Add(string text)
        {
            Logging.Add(text);
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs("Logging"));
        }
    }
