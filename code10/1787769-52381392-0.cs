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
        try
        {
            isExist = File.Exists(Path.Combine(ApplicationData.Current.LocalFolder.Path,fileName)) ? true : false;
        }
        catch (Exception ex)
        {
            return false;
        }
    
        return isExist;
    }
