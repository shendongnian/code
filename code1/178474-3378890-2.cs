    public DataAccess2(string connStr)
    {
        this.connectionString = connStr;
    }
    public DataAccess2()
    {
        this.connectionString = 
                ConfigurationManager.ConnectionStrings["foo"].ConnectionString;
    }
