    string connectionString = $"Data Source=127.0.0.1;Initial Catalog=MyDatabaseName";
    Credential credential = new SqlCredential("myusername", "mypassword");
    SqlConnection connection = new SqlConnection(connectionString, credential);
    connection.Open();
    command = connection.CreateCommand();
    command.CommandType = CommandType.Text;
    command.CommandText = "INSERT INTO dbo.[Policlinic] (id_Policlinic, Name, Address, Phone) VALUES (@id_Policlinic, @Name, @Address, @Phone)";
    //Attention: add the '@' in front of all column names:
    command.Parameters.Add("@id_Policlinic", SqlDbType.Int); 
    command.Parameters["@id_Policlinic"].Value = Convert.ToInt32(textBox62.Text, 4);
    command.Parameters.AddWithValue("@Name", textBox62.Text);
    command.Parameters.AddWithValue("@Address", textBox62.Text);
    command.Parameters.AddWithValue("@Phone", textBox62.Text);
    // Execute command:
    command.ExecuteNonQuery();
    // Parse result here...
    // Close/dispose command and connection:
    command.Dispose();
    connection.Close();
    connection.Dispose();
