      try
      {
        if (i == 2)
        {
          Application.Exit();
        }
        conn.Open();
      string query = "select password from users where username = @usr and password = @pas";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@usr", username);
        cmd.Parameters.AddWithValue("@pas", password);
        MySqlDataReader myreader = cmd.ExecuteReader();
        var password = string.Empty;
        while(myreader.Read())
        {
         password = myreader["password"];
        }
    
         if (password.Equals(password.Text))
         {
          frmMain mainF = new frmMain();
          mainF.Show();
         }
         else
         {
           MessageBox.Show("Username or password is incorrect!");
           i++;
         }
       }
       catch (Exception ex)
       {
       MessageBox.Show("An error has occured while reading from the database!");
       
       }
