    SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.constring.ToString());
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM CLIENTS where cod_cli=@cod", sqlConnection);
        sqlCmd.Parameters.AddWithValue("@cod", cod_cli.Text);
        sqlConnection.Open();
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
        while (sqlReader.Read())
        {
            COMBOBOX1.Items.Add(sqlReader["FR"].ToString());
        }
        sqlReader.Close();
    }
