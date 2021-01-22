public static void StoreGuid(Guid guid)
{
    using (var cnx = new SqlConnection("YourDataBaseConnectionString"))
    using (var cmd = new SqlCommand {
        Connection = cnx,
        CommandType = CommandType.StoredProcedure,
        CommandText = "StoreGuid",
        Parameters = {
            new SqlParameter {
                ParameterName = "@guid",
                <b>SqlDbType = SqlDbType.UniqueIdentifier</b>, // right here
                Value = guid
            }
        }
    })
    {
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
