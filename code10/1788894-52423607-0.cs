    foreach (DataGridViewRow row in dataGridView1.Rows)                   
    { 
        string constring = "Connection String";
        using (MySqlConnection con = new MySqlConnection(constring))
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO db1.table1 (price) VALUES (@price", con))
            {
                cmd.Parameters.AddWithValue("@price", row.Cells["ColumnName"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
