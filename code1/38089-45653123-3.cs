    static class Configuration
    {
        public static string BinPath
        {
            get
            {
                string ConfigPath = ConfigurationManager.AppSettings["StaticClassExample"];
                string SolutionPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                return SolutionPath + ConfigPath;
            }
        }
    }
