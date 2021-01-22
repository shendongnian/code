    public class Settings : INotifyPropertyChanged
    {
        public static Settings Instance { get; private set; }
    
        public static IEnumerable<string> Themes { get; set; }
    
        private string _lastTheme;
        public string LastTheme
        {
            get { return _lastTheme; }
            set
            {
                if (_lastTheme == value)
                    return;
                _lastTheme = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastTheme"));
            }
        }
        
        static Settings()
        {
            Themes = new ObservableCollection<string> { "One", "Two", "Three", "Four", "Five" };
            Instance = new Settings();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
