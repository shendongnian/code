    private void button26_Click(object sender, EventArgs e)
    {
        if (label77.Visible) label77.Visible = false;
        if (string.IsNullOrEmpty(textBox62.Text))
        {
            label77.Visible = true;
            label77.Text = "Поля должны быть заполнены!";
            return;
        }
        SqlConnection connection = null;
        SqlCommand command = null;
        try
        {
            // First create a SQL Connection:
            string connectionString = $"Data Source=127.0.0.1;Initial Catalog=MyDatabaseName";
            Credential credential = new SqlCredential("myusername", "mypassword");
            connection = new SqlConnection(connectionString, credential);
            connection.Open();
            // Then create the SQL command:
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO dbo.[Policlinic] (Name, Address, Phone) VALUES (@Name, @Address, @Phone)";
            // Add '@' in front of all column names:
            command.Parameters.Add(new SqlParameter("@Name", textBox62.Text, 60)
            {
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter("@Address", textBox62.Text, 120)
            {
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            });
            command.Parameters.Add(new SqlParameter("@Phone", textBox62.Text, 20)
            {
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            });
            // Execute command:
            Task.Run(() => command.ExecuteNonQuery()).Wait();
            // Parse any results here...
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null) ex = ex.InnerException;
            MessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Now cleanup this mess:
            command?.Dispose();
            connection?.Close();
            connection?.Dispose();
        }
    }
