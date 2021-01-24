        public static class DataTableExtensions
        {
            public static DataTable RemapInt64ColumnsToInt32(this DataTable table)
            {
                if (table == null)
                    throw new ArgumentNullException();
                for (int iCol = 0; iCol < table.Columns.Count; iCol++)
                {
                    var col = table.Columns[iCol];
                    if (col.DataType == typeof(Int64)
                        && table.AsEnumerable().Where(r => !r.IsNull(col)).Select(r => (Int64)r[col]).All(i => i >= int.MinValue && i <= int.MaxValue))
                    {
                        ReplaceColumn(table, col, typeof(Int32), (o, t) => o == null ? null : Convert.ChangeType(o, t, NumberFormatInfo.InvariantInfo));
                    }
                }
                return table;
            }
            private static DataColumn ReplaceColumn(DataTable table, DataColumn column, Type newColumnType, Func<object, Type, object> map)
            {
                var newValues = table.AsEnumerable()
                    .Select(r => r.IsNull(column) ? (object)DBNull.Value : map(r[column], newColumnType))
                    .ToList();
                var ordinal = column.Ordinal;
                var name = column.ColumnName;
                var @namespace = column.Namespace;
                var newColumn = new DataColumn(name, newColumnType);
                newColumn.Namespace = @namespace;
                table.Columns.Remove(column);
                table.Columns.Add(newColumn);
                newColumn.SetOrdinal(ordinal);
                for (int i = 0; i < table.Rows.Count; i++)
                    if (!(newValues[i] is DBNull))
                        table.Rows[i][newColumn] = newValues[i];
                return newColumn;
            }    
        }
