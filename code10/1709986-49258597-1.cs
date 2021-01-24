    foreach (DataRow row in firstTable.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in firstTable.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
