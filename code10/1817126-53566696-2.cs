        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<string> List { get; set; } = new ObservableCollection<string>()
        {
            "1", "2", "3"
        };
