    public MysqlAccess()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
        // The 'this' keyword is optional here and its usage is a 
        // matter of personal preference
        this.Connection = new MySqlConnection(connectionString);
    }
