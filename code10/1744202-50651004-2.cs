    using (var cn1 = new MySqlConnection("connection string here"))
    using (var sql1 = new MySqlCommand("SELECT * FROM animal WHERE idAnimal = @idAnimal", cn1))
    {
        sql1.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = int.Parse(label1.Text);
        cn1.Open();
        using (var dr1 = sql1.ExecuteReader())
        {    
            while (dr1.Read())
            {
                String idAnimal = dr1["idAnimal"].ToString();
    
                using (var cn2 = new MySqlConnection("connection string here"))
                using (var sql2 = new MySqlCommand("SELECT * FROM town WHERE id = @idAnimal", cn2))
                {
                    cn2.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = int.Parse(idAnimal);
                    cn2.Open();
                    using(var dr2 = sql2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            dataGriedView1.Rows.Add(dr2["number"], dr2["name"]);
                        }
                        dr2.Close();
                    }
                }
            }
            dr1.Close();
        }
    }
