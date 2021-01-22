    using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString))
    using(var command = connection.CreateCommand())
    {
       command.CommandText = "...";
       connection.Open();
       command.ExecuteNonQuery();
    }
