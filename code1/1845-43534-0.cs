    Dictionary<string, string> props = new Dictionary<string, string>();
    props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
    props["Data Source"] = repFile;
    props["Extended Properties"] = "Excel 8.0";
    StringBuilder sb = new StringBuilder();
    foreach (KeyValuePair<string, string> prop in props)
    {
        sb.Append(prop.Key);
        sb.Append('=');
        sb.Append(prop.Value);
        sb.Append(';');
    }
    string properties = sb.ToString();
    using (OleDbConnection conn = new OleDbConnection(properties))
    {
        conn.Open();
        DataSet ds = new DataSet();
        string columns = String.Join(",", columnNames.ToArray());
        using (OleDbDataAdapter da = new OleDbDataAdapter(
            "SELECT " + columns + " FROM [" + worksheet + "$]", conn))
        {
            DataTable dt = new DataTable(tableName);
            da.Fill(dt);
            ds.Tables.Add(dt);
        }
    }
