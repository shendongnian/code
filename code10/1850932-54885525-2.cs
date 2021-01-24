    if(sourceTable.Rows.Count > 0)
    {
        dt = sourceTable.AsEnumerable()
             .Select(x=>x.Field<Int>("NPM"))
             .Distinct()
             .CopyToDataTable();
    }
