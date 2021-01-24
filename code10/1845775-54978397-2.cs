    private ObservableCollection<SampleModel> list { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            list = new ObservableCollection<SampleModel>
    {
    new SampleModel { Id = 1, Description = "Apple" },
    new SampleModel { Id = 2, Description = "Orange" },
    new SampleModel { Id = 3, Description = "Banana" }
    }; 
        }
