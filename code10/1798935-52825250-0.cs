     public static DataTable getCompartmentList(int module, string compID, string compDesc, string compType, string equipMake, string equipModel, string compMake, int compSize)
                {
                    string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["TTDALConnection"].ConnectionString;
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(cnnString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetCompartmentsList";
        
        
                            cmd.Parameters.Add(new SqlParameter("@progid", module));
                            cmd.Parameters.Add(new SqlParameter("@compId", SqlDbType.VarChar));
        
        
                            if (compID == null)
                                cmd.Parameters["@compId"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@compId"].Value = compID;
        
                            cmd.Parameters.Add(new SqlParameter("@compDesc", SqlDbType.VarChar));
                            if (compDesc == null)
                                cmd.Parameters["@compDesc"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@compDesc"].Value = compDesc;
        
                            cmd.Parameters.Add(new SqlParameter("@compType", SqlDbType.VarChar));
                            if (compType == null)
                                cmd.Parameters["@compType"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@compType"].Value = compType;
        
                            cmd.Parameters.Add(new SqlParameter("@equipMake", SqlDbType.VarChar));
                            if (equipMake == null)
                                cmd.Parameters["@equipMake"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@equipMake"].Value = equipMake;
        
                            cmd.Parameters.Add(new SqlParameter("@equipModel", SqlDbType.VarChar));
                            if (equipModel == null)
                                cmd.Parameters["@equipModel"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@equipModel"].Value = equipModel;
        
                            cmd.Parameters.Add(new SqlParameter("@compMake", SqlDbType.VarChar));
                            if (compMake == null)
                                cmd.Parameters["@compMake"].Value = DBNull.Value;
                            else
                                cmd.Parameters["@compMake"].Value = compMake;
        
                            cmd.Parameters.Add(new SqlParameter("@compSize", compSize));
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                    return dt;
                }
