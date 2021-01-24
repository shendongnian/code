    var startcolumnindex=21;
          //  RemoveEmptyColumns
                for (int i = dt.Columns.Count - 1; i >= startcolumnindex; i--)
                {
                    DataColumn col = dt.Columns[i];
                    if (dt.AsEnumerable().All(r => r.IsNull(col) || string.IsNullOrWhiteSpace(r[col].ToString())))
                        dt.Columns.RemoveAt(i);
                }
                //  RemoveEmptyColumns
