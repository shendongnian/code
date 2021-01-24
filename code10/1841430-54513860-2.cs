     protected void Button1_Click(object sender, EventArgs e)
     {
        using (var connection = new MySqlConnection("Server=tcp:xxxx.database.windows.net,1433;Initial Catalog=xxxx;Persist Security Info=False;User ID=xxxxx;Password=xxxxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        {
            MySqlCommand command = new MySqlCommand("InsertFullname", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("Fullname", TextBox1.Text));
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            command.Connection.Close();
        } 
     }
