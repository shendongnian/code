    public static string GetNameByID(int nameID)
            {
                SqlParameter[] parameters = new SqlParameter[1];
    
                parameters[0] = new SqlParameter("@NameID", 
                    System.Data.SqlDbType.Int, 8, "nameID");
                        parameters[0].Value = nameID;
    
                try
                {
                    return (SqlHelper.ExecuteNonQuery(dbConnection, 
                        CommandType.StoredProcedure,
                            "GetNameByID", parameters));
                }
                catch
                {
                    throw;
                }
                finally
                {
                    dbConnection.Close();
                }
            }
