    public static class Employee
    {
        private static NameValueCollection _appSettings=ConfigurationManager.AppSettings;
    
        public static NameValueCollection AppSettings { get { return _appSettings; } }
    
    }
