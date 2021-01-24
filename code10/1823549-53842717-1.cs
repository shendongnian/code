    public static DataTable ToDataTable<T>(this IEnumerable<T> rows) {
        var dt = new DataTable();
        if (rows.Any()) {
            var rowType = typeof(T);
            var memberInfos = rowType.GetPropertiesOrFields();
            foreach (var info in memberInfos)
                dt.Columns.Add(new DataColumn(info.Name, info.GetMemberType()));
            foreach (var r in rows)
                dt.Rows.Add(memberInfos.Select(i => i.GetValue(r)).ToArray());
        }
        return dt;
    }
