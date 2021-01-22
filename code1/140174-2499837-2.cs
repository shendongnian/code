    public static DataRow[] GetRowsForDir(DataTable table, string targetDir)
    {
        var result = new List<DataRow>();
    
        foreach (DataRow row in table.Rows)
        {
            if (Path.GetDirectoryName(((string)row["FilePath"])).Equals(targetDir))
            {
                result.Add(row);
            }
        }
    
        return result.ToArray();
    }
