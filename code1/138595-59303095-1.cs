     private static DataTable _makeTableFromRange(List<Range> ranges)
        {
            var table = new DataTable();
            foreach (var range in ranges)
            {
                while (table.Columns.Count < range.Column)
                {
                    table.Columns.Add();
                }
                while (table.Rows.Count < range.Row)
                {
                    table.Rows.Add();
                }
                table.Rows[range.Row - 1][range.Column - 1] = range.Value2;
            }
            //clean from empty rows
            var filteredRows = table.Rows.Cast<DataRow>().
                            Where(row => !row.ItemArray.All(field => field is System.DBNull ||
                                                                     string.Compare((field as string).Trim(), string.Empty) ==
                                                                     0));
            table = filteredRows.CopyToDataTable();
            return table;
        }
