    foreach (string s in GetMetaData())
    {
        restrictions[2] = s;
        DataTable schemaTable = con.GetSchema("Tables", restrictions);
        result.Add(s, new List<string>());
        foreach (DataRow row in schemaTable.Rows)
        {
            result[s].Add(row[2].ToString());
        }
    }
