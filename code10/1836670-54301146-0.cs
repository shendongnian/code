    private void button2_Click(object sender, EventArgs e)
    {
        var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\equipment.accdb");
        var command = connection.CreateCommand();
        // query string example
        command.CommandText = "SELECT * FROM TableName WHERE SerialNumber = ?"; 
        command.Parameters.AddWithValue("SerialNumber", (textBox1.Text));
        connection.Open(); // open the connection
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            textBox2.Text = reader["EquipmentBrand"].ToString();
            textBox3.Text = reader["EquipmentType"].ToString();
        }
    }
