    using (var connection = new SqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
        var query = @"
            SELECT * FROM Main_Information
            WHERE [First Name] LIKE @firstName AND [Last Name] LIKE @lastName";
        var parameters = new [] 
        {
            new SqlParameter
            {
                ParameterName = "@firstName",
                SqlDbType = SqlDbType.VarChar,
                Value = txtFirstName.Text
            },
            new SqlParameter
            {
                ParameterName = "@lastName",
                SqlDbType = SqlDbType.VarChar,
                Value = txtLastName.Text
            }
        }   
       
        command.CommandText = query;
        command.Parameters.AddRange(parameters);
        connection.Open();
        var adapter = new SqlDataAdapter(command);
        var data = new DataTable();
        adapter.Fill(data);
        dgvAdvisor.DataSource = data;
    }
