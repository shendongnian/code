    public void ReadData(string connectionString)
    {
       string queryString = "SELECT A,B,C,D FROM XXXXX";
       using (var connection = new OracleConnection(connectionString))
       {
           var command = new OracleCommand(queryString, connection);
           connection.Open();
           using(OracleDataReader reader = command.ExecuteReader())
           {
    	       while (reader.Read())
               {
        	       Console.WriteLine("{0}, {1}, {2}, {3}",
                                     reader.GetDateTime(0),
                                     reader.GetDateTime(1),
                                     reader.GetDateTime(2),
                                     reader.GetDateTime(3));
     	       }
           }
      }
    }
