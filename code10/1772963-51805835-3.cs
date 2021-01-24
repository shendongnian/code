    using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    cmd.Connection = new SqlConnection(connectionString);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 900;
                    cmd.CommandText = "Lab_GetDefinitionList";
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.Connection.Open();
                    //
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    
                    da.Fill(ds);
                    cmd.Connection.Close();
                    // **check if return data**
                    if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                         result.Elements.Add(ds.Tables[0].Rows[0]["YourColumnName"].ToString());
    
                }
