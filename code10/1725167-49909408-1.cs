      query= "INSERT INTO history(iddata,description, datehist" VALUES(@id,@descrip,GETDATE())";
       using (SqlConnection con = new SqlConnection(myDBtwo))
                {
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
