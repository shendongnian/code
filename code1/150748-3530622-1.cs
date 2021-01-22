    Properties.Settings.Default.Language = "en";
    Properties.Settings.Default.Save();
    public Form1()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Language);
        //...
        InitializeComponent();
    }
