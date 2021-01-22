      using System.Data.SqlClient;
      using(SqlConnection connection = new SqlConnection(connectionString))
      using(SqlCommand command = connection.CreateCommand())
      {
        string script = File.ReadAllText("script.sql");
        command.CommandText = script.Replace("GO", "");
        connection.Open();
        int affectedRows = command.ExecuteNonQuery();
      }
