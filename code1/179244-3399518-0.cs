    DataTable results = new DataTable();
    using(MySqlConnection conn = new MySqlConnection(connString))
    {
        using(MySqlCommand command = new MySqlCommand(sqlQuery, conn))
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            conn.Open();
            adapter.Fill(results);
        }
    }
    someDataGrid.DataSource = results;
    someDataGrid.DataBind();
