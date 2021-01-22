    public static class Helper
    {
        public static string Foo 
        { 
            get
            {
                return ConfigurationManager.AppSettings["Foo"];
            }
        }
    }
