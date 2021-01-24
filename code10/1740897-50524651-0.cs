    class LogModel
    {
        public ObservableCollection<string> Logging { get; } = new ObservableCollection<string>();
        public void Add(string text)
        {
            Logging.Add(text);
        }
    }
