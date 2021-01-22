    public int Login(string connectionString,string username,string password)
    {
      using(var con = new SqlConnection(connectionString)) {
        con.Open();
        var cmdText = "SELECT password from USER where username=@username";
        using (var cmd = new SqlCommand(cmdText, con)) {
        
          cmd.Parameters.AddWithValue("@username", username);
          object passwordFromDb = userCmd.ExecuteScalar();
          if (passwordFromDb != null) {
              if (password == passwordFromDb.ToString()) {
                return 1;
              }
          }
        }
      }
      return 0;
    }
