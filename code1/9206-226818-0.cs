    Dictionary<string,DataTable> Tables = new Dictionary<string,DataTable>();
    // ... populate dictionary of tables ...
    XElement TableRoot = new XStreamingElement("Tables",
        from t in Tables
        select new XStreamingElement(t.Key,
                   from DataRow r in t.Value.Rows
                   select new XStreamingElement("row",
                              from DataColumn c in t.Value.Columns
                              select new XElement(c.ColumnName, r[c])))))
