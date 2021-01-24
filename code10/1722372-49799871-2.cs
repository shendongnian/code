        public ObservableCollection<CameraSetting> CameraSettingsList { get; set; } = new ObservableCollection<CameraSetting>();
        public MainPage()
        {
            this.InitializeComponent();
            this.CameraSettingsList.Add(new CameraSetting()
            {
                Property = "prop1",
                Auto = true,
                Value1 = new List<string>() { "Option 1", "Option 2" },
                Value2 = new List<string>() { "Option 3", "Option 4" },
            });
        }
