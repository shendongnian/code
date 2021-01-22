    public DbConnection()
	{        
        connection = new SqlConnection("Data Source=****; User Id=****; Password=*****;");
        connection.Open();
        command = connection.CreateCommand();
	}
