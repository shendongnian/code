     private static void SetDateTimeMode(DataTable table, DataColumn col, DataSetDateTime mode)
            {
                var rowValues = new object[table.Rows.Count];
    
                for (int i = 0; i < rowValues.Length; i++)
                {
                    // ignore deleted rows
                    if (table.Rows[i].RowState == DataRowState.Deleted) continue;
    
                    rowValues[i] = table.Rows[i][col];
                }
    
                // we must remove and re-add the row because DateTimeMode cannot be
                // changed on a column that has data.
                table.Columns.Remove(col);
    
                col.DateTimeMode = mode;
    
                table.Columns.Add(col);
    
                // write back each row value
                for (int i = 0; i < rowValues.Length; i++)
                {
                    // ignore deleted rows
                    if (table.Rows[i].RowState == DataRowState.Deleted) continue;
    
                    var rowState = table.Rows[i].RowState;
    
                    table.Rows[i][col] = rowValues[i];
    
                    // preserve unchanged rowstate
                    if (rowState == DataRowState.Unchanged)
                        table.Rows[i].AcceptChanges();
                }
            }
