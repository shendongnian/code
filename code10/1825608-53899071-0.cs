    private async Task UpdateDatabase()
    {
        using (var connection = new SqlConnection(connectionString))
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT Id FROM Table";
            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                var rowsCount = 0;
                // Since execution will happen on same thread 
                // you will be able update UI controls.
                Label1.Text = $"Rows: {rowsCount}";
                while (await reader.ReadAsync())
                {
                    rowsCount ++;
                    Label1.Text = $"Rows: {rowsCount}";
                }
            }
        }
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        await UpdateDatabase();
        button1.Enabled = true;
    }
