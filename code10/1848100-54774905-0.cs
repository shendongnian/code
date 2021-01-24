    public YourPageName()
        {
            this.InitializeComponent();
            ComboBox2.ItemsSource = File.ReadAllLines(@"c:\temp\servers.txt");
        }
