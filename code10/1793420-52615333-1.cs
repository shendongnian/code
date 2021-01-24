    public static DataTable ToDataTable(this IEnumerable<IDictionary<string, string>> rows) {
        var dt = new DataTable();
        if (rows.Any()) {
            foreach (var kv in rows.First())
                dt.Columns.Add(kv.Key, typeof(String));
            foreach (var r in rows)
                dt.Rows.Add(r.Values.ToArray());
        }
        return dt;
    }
