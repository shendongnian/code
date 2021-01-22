    public static DataTable JoinTwoTables(DataTable innerTable, DataTable outerTable)
            {
                DataTable resultTable = new DataTable();
                var innerTableColumns = new List<string>();
                foreach (DataColumn column in innerTable.Columns)
                {
                    innerTableColumns.Add(column.ColumnName);
                    resultTable.Columns.Add(column.ColumnName);
                }
    
                var outerTableColumns = new List<string>();
                foreach (DataColumn column in outerTable.Columns)
                {
                    if (!innerTableColumns.Contains(column.ColumnName))
                    {
                        outerTableColumns.Add(column.ColumnName);
                        resultTable.Columns.Add(column.ColumnName);
                    }                    
                }
    
                for (int i = 0; i < innerTable.Rows.Count; i++)
                {
                    var row = resultTable.NewRow();
                    innerTableColumns.ForEach(x =>
                    {
                        row[x] = innerTable.Rows[i][x];
                    });
                    outerTableColumns.ForEach(x => 
                    {
                        row[x] = outerTable.Rows[i][x];
                    });
                    resultTable.Rows.Add(row);
                }
                return resultTable;
            }
