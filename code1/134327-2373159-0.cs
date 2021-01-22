    using (SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=JunkBox;Integrated Security=SSPI;"))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO JunkSO(Id, Name) VALUES(@Id, @Description)  SELECT * FROM JunkSO", conn);
                    cmd.Parameters.AddWithValue("@Id", 10);
                    cmd.Parameters.AddWithValue("@Description", "TestDescription");
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                MessageBox.Show(rd[0].ToString() + "  " + rd[1].ToString());
                            }
                        }
                    }
                }
