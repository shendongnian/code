               con.Open();
       SqlCommand com = new SqlCommand(query,con);
                    foreach (DataRow x in dt.Rows)
                    {     
                            com.Parameters.Add(new SqlParameter("@id", x["idoper"].ToString()));
                            com.Parameters.Add(new SqlParameter("@descrip", x["description"] ));
                            com.ExecuteNonQuery();
                        }
                    }
                }
