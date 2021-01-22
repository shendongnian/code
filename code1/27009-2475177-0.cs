    AppDomainSetup setup = new AppDomainSetup();
    setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
    AppDomain app = AppDomain.CreateDomain("YaCsi", null, setup);
    app.DoCallBack(LoaderCallback);
    AppDomain.Unload(app);
    File.Delete("__YaCsi_Test01.dll");
    
    static void LoaderCallback()
    {
    	byte[] raw = File.ReadAllBytes("__YaCsi_Test01.dll");
    	Assembly yacsi = Assembly.Load(raw);
    	((IScript)yacsi.CreateInstance("Script")).Go();
    }
