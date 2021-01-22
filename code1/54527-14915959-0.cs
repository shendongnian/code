        public MainWindow()
        {
            FormSizeSaver.RegisterForm(this, () => Settings.Default.MainWindowSettings,
                                       s =>
                                       {
                                           Settings.Default.MainWindowSettings = s;
                                           Settings.Default.Save();
                                       });
            InitializeComponent();
            ...
