        public string processorType { get; set; }
        public Settings Settings { get; set; } = new Settings()
        {
            isEnabled = false
        };
        public bool IsEnabled => Settings.isEnabled;
        public Processor()
        {
            Settings.PropertyChanged += Settings_PropertyChanged;
        }
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEnabled));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Settings : INotifyPropertyChanged
    {
        private bool _isEnabled;
        public bool isEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
