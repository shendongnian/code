    using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
    try{
        using(var command = connection.CreateCommand())
        {
           command.CommandText = "...";
           connection.Open();
           command.ExecuteNonQuery();
        }
    }
    catch(Exception ex){ //Log exception according to your own way
    	throw;
    }
    finally{
    	command.Dispose();
    	connection.Close();
    	connection.Dispose();
    }
