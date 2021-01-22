        public static Range LoadFromDataTable(this Worksheet ws, int startRow, int startCol, System.Data.DataTable dt)
        {
            var columnHeaders = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnHeaders.Add(dt.Columns[i].ColumnName);
            }
            ws.Range[ws.Cells[startRow, startCol], ws.Cells[startRow, startCol + dt.Columns.Count - 1]].Value2 = columnHeaders.ToArray();
            //Transfer dt data to 2d array
            var data = new object[dt.Rows.Count, dt.Columns.Count];
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    data[rowIndex, colIndex] = dt.Rows[rowIndex][colIndex];
                }
            }
            ws.Range[ws.Cells[startRow + 1, startCol], ws.Cells[startRow + dt.Rows.Count, startCol + dt.Columns.Count - 1]].Value2 =
                data;
            var rng = ws.Range[ws.Cells[startRow, startCol], ws.Cells[startRow + dt.Rows.Count, startCol + dt.Columns.Count - 1]];
            return rng;
        }
