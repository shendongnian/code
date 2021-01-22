    public MysqlAccess()
    {
        // Here you are initializing a local variable 
        // that is subject to GC and goes into the void of forgetfulness
        MySqlConnection Connection=new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
    }
