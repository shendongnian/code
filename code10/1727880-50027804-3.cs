    Credential credential = null;
    SqlConnection connection = null;
    try
    {
        // First create a SQL Connection:
        string connectionString = $"Data Source=127.0.0.1;Initial Catalog=MyDatabaseName";
        credential = new SqlCredential("myusername", "mypassword");
        connection = new SqlConnection(connectionString, credential);
        connection.Open();
        // Then create the SQL command:
        command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "INSERT INTO dbo.[Policlinic] (id_Policlinic, Name, Address, Phone) VALUES (@id_Policlinic, @Name, @Address, @Phone)";
        // Add '@' in front of all column names:
        command.Parameters.Add(new SqlParameter("@id_Policlinic", Convert.ToInt32(textBox62.Text, 4))
        {
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Input
        });
        command.Parameters.Add(new SqlParameter("@Name", textBox62.Text)
        {
            SqlDbType = SqlDbType.NVarChar,
            Direction = ParameterDirection.Input
        });
        command.Parameters.Add(new SqlParameter("@Address", textBox62.Text)
        {
            SqlDbType = SqlDbType.NVarChar,
            Direction = ParameterDirection.Input
        });
        command.Parameters.Add(new SqlParameter("@Phone", textBox62.Text)
        {
            SqlDbType = SqlDbType.NVarChar,
            Direction = ParameterDirection.Input
        });
        // Execute command:
        command.ExecuteNonQuery();
        // Parse any results here...
    }
    catch (Exception ex)
    {
        MessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        // Now cleanup this mess:
        command?.Dispose();
        connection?.Close();
        connection?.Dispose();
    }
