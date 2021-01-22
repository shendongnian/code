    public DbConnection()
	{        
        connection = new SqlConnection("Data Source=kamino.nith.no; User Id=sysarv; Password=sysarv;");
        connection.Open();
        command = connection.CreateCommand();
	}
