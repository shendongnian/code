    public void buildConnection(string sConnectionString){
       //Some code, variables, etc
    
       _serverConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[sConnectionString]);
    
       //Some more code, etc etc
    
    }
