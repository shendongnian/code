    using (SqlConnection con = new SqlConnection(strConnect))
    {
    con.Open();
    using (SqlCommand com = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", con))
        {
        using (SqlDataReader reader = com.ExecuteReader())
            {
            myComboBox.Items.Clear();
            while (reader.Read())
                {
                myComboBox.Items.Add((string) reader["TABLE_NAME"]);
                }
            }
        }
    }
