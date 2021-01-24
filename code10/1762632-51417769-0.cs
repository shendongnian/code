        /// <summary>
        /// Puts a border around cells
        /// </summary>
        /// <param name="r1">First Row</param>
        /// <param name="c1">First Column</param>
        /// <param name="r2">Last Row</param>
        /// <param name="c2">Last Column</param>
        /// <param name="weight">Border Brush Weight</param>
        public void BorderCells(Worksheet ws, int r1, int c1, int r2, int c2, int weight)
        {
            Range r = ws.Range[ws.Cells[r1, c1], ws.Cells[r2, c2]];
            r.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            r.Borders.Weight = weight;
        }
