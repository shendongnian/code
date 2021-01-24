      //for connection parameters
      private static string connectionString = "datasource=localhost;"+
                                    "port=3306;"+
                                    "Initial Catalog='authorization_schema';"+
                                    "username=admin;"+
                                    "password=admin123;";
      MySqlConnection connection = new MySqlConnection(connectionString);
      // construct SQL command with parameters (this way you can call SP also)
      IDbCommand cmd = new MySqlCommand("SELECT account, action FROM AUTHORIZATIONS WHERE username=@UserName", connection);
      // construct parameters
      MySqlParameter usernameParam = new MySqlParameter();
      usernameParam.ParameterName = "@UserName";
      usernameParam.Value = username;
      
      cmd.Parameters.Add(usernameParam);
      / construct data adapter
      IDataAdapter adapter = new MySqlDataAdapter((MySqlCommand)cmd);
      // construct DataSet to store result
      DataSet ds = new DataSet();
      adapter.Fill(ds);
