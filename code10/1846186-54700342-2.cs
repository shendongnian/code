    public List<string> Exec()
    {
        var names = new List<string>();
        var results = New DataTable();
        // methodToExecuteSP is = public DataSet 
        results = methodToExecuteSP;
        foreach (DataRow row in results.Rows)
        {
            result.Add(row[“Name”].ToString());
        }
        return names;
    }
