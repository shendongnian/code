    // Create new DataTable from LINQ results on DataTable
    // Expect T to be anonymous object of form new { DataRow d1, DataRow d2, ... }
    public static DataTable FlattenToDataTable<T>(this IEnumerable<T> src) {
        var res = new DataTable();
        if (src.Any()) {
            var firstRow = src.First();
            var rowType = typeof(T);
            var memberInfos = rowType.GetPropertiesOrFields();
            var allDC = memberInfos.SelectMany(mi => mi.GetValue<DataRow>(firstRow).Table.DataColumns());
            foreach (var dc in allDC) {
                var newColumnName = dc.ColumnName;
                if (res.ColumnNames().Contains(newColumnName)) {
                    var suffixNumber = 1;
                    while (res.ColumnNames().Contains($"{newColumnName}.{suffixNumber}"))
                        ++suffixNumber;
                    newColumnName = $"{newColumnName}.{suffixNumber}";
                }
                res.Columns.Add(new DataColumn(newColumnName, dc.DataType));
            }
            foreach (var objRows in src)
                res.Rows.Add(memberInfos.SelectMany(mi => mi.GetValue<DataRow>(objRows).ItemArray).ToArray());
        }
        return res;
    }
