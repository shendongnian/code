    public static class Employee
    {
        public static string SomeSetting
        {
            get 
            {
    	        return ConfigurationManager.AppSettings["SomeSetting"];    
            }
        }
    }
