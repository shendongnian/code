    private void SetupDatabase(string dbFolder, string dbName)
    {
      if (Directory.Exists(String.Format("{0}\\db", dbFolder)) == false)
      {
        Directory.CreateDirectory(String.Format("{0}\\db", dbFolder));
      }
      if (File.Exists(String.Format("{0}\\db\\{1}_Data.mdf", dbFolder, dbName)) == false)
      {
        ExecuteQuery(
          "master",
          String.Format("CREATE DATABASE {1} ON PRIMARY (NAME = {1}_Data, FILENAME = '{0}\\db\\{1}_Data.mdf', SIZE = 2MB, FILEGROWTH = 10%) LOG ON (NAME = {1}_Log, FILENAME = '{0}\\db\\{1}_Log.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)", dbFolder, dbName));
      }
    }
    private void ExecuteQuery(
      string db,
      string query)
    {
      SqlConnection connection = null;
      try
      {
        connection = new SqlConnection(string.Format(connectionString, db));
        connection.Open();
        // Creates DB
        using (SqlCommand command = new SqlCommand(query, connection))
        {
          command.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        connection.Close();
      }
    }
