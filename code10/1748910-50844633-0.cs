    private static List<SelectListItem> GetFruits(Fruits bf)
    {
        var items = new List<SelectListItem>();
        string constr = "Your connection string here";
        using (var con = new SqlConnection(constr))
        {
            var query = " SELECT ID, Fruits FROM FruitItems where Mobileno=@Mobileno";
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Mobileno", bf.Mobileno);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new SelectListItem();
                            item.Value = reader.GetInt32(reader.GetOrdinal("Id")).ToString();
                            item.Text = reader.GetString(reader.GetOrdinal("Fruits"));
                            items.Add(item);
                        }
                    }
                }
            }
        }
        return items;
    }
