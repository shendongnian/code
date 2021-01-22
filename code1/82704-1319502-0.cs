    public static class ApplicationSettings
    {
        public static string InstallDirectory { get { ... } set { ... } };
        public static DataSet SomeDataSet { get { ... } set { ... } };
    
    
        static ApplicationSettings()
        {
           // ... initialize or load settings here
        }
    }
