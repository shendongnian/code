    string sql = "SELECT t.number, t.name FROM animal a INNER JOIN town t ON t.ID = a.idAnimal WHERE a.idAnimal= @idAnimal";
    using (var cn = new MySqlConnection("connection string here"))
    using (var cmd = new MySqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = int.Parse(label1.Text);
        cn.Open();
        using (var dr = cmd.ExecuteReader())
        {
            while(dr.Read())
            {
                dataGridView1.Rows.Add(dr["number"], dr["name"]);
            }
            dr.Close();
        }
    }
