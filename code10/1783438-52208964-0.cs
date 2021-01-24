	string connectionString = (some condition)
		? ConfigurationManager.ConnectionStrings["REMOTE"].ConnectionString
		: ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
	using(var con = new SqlConnection(connectionString))
	{
       // code using your SqlConnection instance
	}
