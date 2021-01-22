    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        int index = baseDir.IndexOf("TestResults");
        string dataDir = baseDir.Substring(0, index) + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
    }
