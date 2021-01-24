    public WelcomeScreen()
            {
                InitializeComponent();
                this.DataContext = new WelcomeScreenViewModel(Settings.Default.CurrentEmailAddress);
            }
