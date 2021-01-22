    using(OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
    {
      using(OleDbCommand command = connection.CreateCommand())
      {
        command.CommandType = CommandType.Text;
        command.CommandText = "INSERT INTO DVD(title,locatie)VALUES(?,?)";
        command.Parameters.Add("@p1", OleDbType.VarChar, 1).Value = M.Title;
        command.Parameters.Add("@p2", OleDbType.VarChar, 255).Value = M.Location;
    
        connection.Open();
        int ret = command.ExecuteNonQuery();
      }
    }
