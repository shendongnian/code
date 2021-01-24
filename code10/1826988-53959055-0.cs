    // Keep Sql being readable
    string insertQuery = 
      @"SELECT UserID 
          FROM Customers 
         WHERE Email = @Email 
           AND Password = @Password";
    
    // Do not forget to dispose IDisposable
    using (SqlCommand com = new SqlCommand(insertQuery, conn)) {
      com.Parameters.AddWithValue("@Email", tbEmail.Text);
      com.Parameters.AddWithValue("@Password", tbPassword.Text);
    
      using (var reader = com.ExecuteReader()) {
        string result = reader.Read()
          ? Convert.ToString(reader[0]) // record exists
          : null;                       // cursor is empty
        //TODO: put relevant code which works with result here
      }
    }
