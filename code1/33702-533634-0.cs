    protected void FillFromDatabase( string sql, BaseDataBoundControl dataControl)
    {
	SqlDataReader reader = null;
	var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
	var conn = new SqlConnection( connectionString );
	var comm = new SqlCommand( sql, conn );
	try
	{
		conn.Open();
		reader = comm.ExecuteReader();
		dataControl.DataSource = reader;
		dataControl.DataBind();
	}
	finally
	{
		if( reader != null )
			reader.Dispose();
		conn.Dispose();
	}
    }
