    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;
    
        if (!CheckFileExists("Tryout.sqlite"))
        {
            CopyDatabase();
        }
    
    }
    private bool CheckFileExists(string fileName)
    {
        bool isExist;
        isExist = File.Exists(Path.Combine(ApplicationData.Current.LocalFolder.Path,fileName)) ? true : false;
        return isExist;
    }
