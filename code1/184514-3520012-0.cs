    Func<DataRow, dynamic> projection =
        r =>
        {
            IDictionary<string, object> exp = new ExpandoObject();
            foreach (DataColumn col in r.Table.Columns)
                exp[col.ColumnName] = r[col];
            return exp;
        };
    
    dynamic[] objects = dataTable.AsEnumerable().Select(projection).ToArray();
    ...
    dynamic o = objects[0];
    int id = o.Id;
    string name = o.Name;
