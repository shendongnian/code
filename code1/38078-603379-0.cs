    public static class ConfigManager 
    {
        public static string MyBaseDir
        {
            return ConfigurationManager.AppSettings["MyBaseDir"].toString();
        }
    
        public static string Dir1
        {
            return MyBaseDir + ConfigurationManager.AppSettings["Dir1"].toString();
        }
    
    }
