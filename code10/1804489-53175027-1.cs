        public MainWindowViewModel()
        {
            NameList = new ObservableCollection<string>()
            {
                "John", "Micheal", "Jack"
            };
        }
        public ObservableCollection<string> NameList { get; set; }
        public bool IsMenuItem1Checked
        {
            get { return _isMenuItem1Checked; }
            set { SetProperty(ref _isMenuItem1Checked, value); }
        }
