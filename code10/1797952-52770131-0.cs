       List<string> hawhaw = new List<string>();
    
                using (SqlConnection connection = new SqlConnection("data source = . ; database = tnt ; integrated security = true ; MultipleActiveResultSets=true"))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("select matricule from inscription where numformation = @n", connection))
                    {
                        cmd.Parameters.AddWithValue("@n", comboBox2.Text);
                        SqlDataReader dr = cmd.ExecuteReader();
    
                        while (dr.Read())
                        {
                            hawhaw.Add(dr[0].ToString());
                        }
    
                    }
                }
    
    
    
                using (var connection = new SqlConnection("data source = . ; database = tnt ; integrated security = true ; MultipleActiveResultSets=true"))
                {
                    connection.Open();
    
                    foreach (var item in hawhaw)
                    {
                        using (var cmd2 = new SqlCommand("select * from person where matricule = @m", connection))
                        {
                            cmd2.Parameters.AddWithValue("@m", item);
                            var dr2 = cmd2.ExecuteReader();
                            if (dr2.Read())
                            {
                                MessageBox.Show(dr2[0].ToString());
                            }
                        }
    
                    }
                }
