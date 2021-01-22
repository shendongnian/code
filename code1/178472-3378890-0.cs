    public DataAccess2()
    {
        this.connectionString = 
                ConfigurationManager.ConnectionStrings["foo"].ConnectionString;
    }
