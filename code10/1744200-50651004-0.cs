    string sql = "SELECT * FROM animal a INNER JOIN town t ON t.ID = a.idAnimal WHERE a.idAnimal= @idAnimal";
    using (var cn = new MySqlConnection("connection string here"))
    using (var cmd = new MySqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@idAnimal", MySqlDbType.Int323).Value = int.Parse(label1.Text);
        cn.Open();
        using (var dr = cmd.ExecuteReader())
        {
            while(dr.Read())
            {
                dataGriedView1.Rows.Add(dr2["number"], dr2["name"]);
            }
            dr.Close();
        }
    }
