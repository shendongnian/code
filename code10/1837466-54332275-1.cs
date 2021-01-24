    txtIdOutput.Text = string.Empty;
    using(var connection = new SqlConnection(conString))
    {
        connection.Open();
        using(var command = connection.CreateCommand())
        {
             command.CommandText = "SELECT id FROM test WHERE name LIKE @name";
             command.Parameters.AddWithValue("@name", txtNameInput.Text);
              using(var reader = command.ExecuteReader())
              {
                   while(reader.Read())
                   {
                       txtIdOutput.Text += reader.GetValue(0).ToString();
                   }
              }
        }
    }
