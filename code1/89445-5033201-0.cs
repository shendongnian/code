        public static void StoreGuid(Guid guid)
        {
            using (SqlConnection cnx = new SqlConnection("YourDataBaseConnectionString"))
            {
                using (SqlCommand cmd = new SqlCommand("spStoreGuid", cnx) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add(new SqlParameter("@Guid", guid) { SqlDbType = SqlDbType.UniqueIdentifier });
                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();                        
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error executing procedure spStoreGuid.", ex);
                    }
                }
            }
        }
