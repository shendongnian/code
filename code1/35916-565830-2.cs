    using (SqlConnection connSource = new SqlConnection(csSource))
    using (SqlCommand cmd = connSource.CreateCommand())
    using (SqlBulkCopy bcp = new SqlBulkCopy(csDest))
    {
        bcp.DestinationTableName = "SomeTable";
        cmd.CommandText = "myproc";
        cmd.CommandType = CommandType.StoredProcedure;
        connSource.Open();
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
            bcp.WriteToServer(reader);
        }
    }
