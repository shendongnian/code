    public MySqlConnection CreateConnection(string name)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentException("Connection name must be provided", "name");
        
      string connection = ConfigurationManager.ConnectionStrings[name].ConnectionString;
      return new MySqlConnection(connection);
    }
    
