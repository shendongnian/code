    foreach (string s in GetMetaData())
    {
        restrictions[2] = s;
        DataTable schemaTable = con.GetSchema("Tables", restrictions);
        foreach (DataRow row in schemaTable.Rows)
        {
            result.Add(row[2].ToString());
        }
    }
