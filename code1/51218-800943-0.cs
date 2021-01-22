    public class DataConnection
    {
    
    
        public static string NameOfConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NameOfConnection"].ConnectionString;
            }
        }
    }
