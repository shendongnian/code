                    for (int i = 0; i < listBServices.Items.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT price FROM price WHERE service = @svc",
                                    con.Connection);
                        cmd.Parameters.Add("@svc", SqlDbType.VarChar).Value = listBServices.Items[i].ToString();
                        SqlDataReader rd = cmd.ExecuteReader();
        
                        while (rd.Read())
                        {                    
                            listBPrice.Items.Add(rd["price"].ToString());
                        }
                        rd.Close();
                    }
