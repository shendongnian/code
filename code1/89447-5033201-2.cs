    public static void StoreGuid(Guid guid)
    {
        using (var cnx = new SqlConnection("YourDataBaseConnectionString"))
        using (var cmd = new SqlCommand("StoreGuid", cnx) { CommandType = CommandType.StoredProcedure })
        {
            cmd.Parameters.Add(new SqlParameter("@guid", guid) { SqlDbType = SqlDbType.UniqueIdentifier });
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("wtfguid", ex);
            }
        }
    }
