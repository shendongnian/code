    public static class ConnectionStrings
    {
        public static string StacyesCakes 
        { 
            get 
            { 
                ConfigurationManager.ConnectionStrings[
                      "staceys_cakesConnectionString"].ConnectionString; 
            }
        }
    }
