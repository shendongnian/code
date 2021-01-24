    using (OdbcCommand oCmd = new OdbcCommand())
    {
        oCmd.Connection = oConn;
        oCmd.CommandType = System.Data.CommandType.Text;
        oCmd.CommandText = "select A   from [" + lstrFileName + "$]";
        using (OdbcDataReader reader = oCmd.ExecuteReader())
        {
            object[] fields = new object[reader.FieldCount];
            while (reader.Read())
            {
                reader.GetValues(fields);
                // do something with fields
            }
        }
    }
