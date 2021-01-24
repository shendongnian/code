        /// <summary>
        /// Puts a border around range
        /// </summary>
        /// <param name="ws">Excel worksheet</param>
        /// <param name="r1">First Row</param>
        /// <param name="c1">First Column</param>
        /// <param name="r2">Last Row</param>
        /// <param name="c2">Last Column</param>
        /// <param name="weight">Border Brush Weight</param>
        public void BorderRange(Worksheet ws, int r1, int c1, int r2, int c2, XlBorderWeight weight = XlBorderWeight.xlThin)
        {
            Range r = ws.Range[ws.Cells[r1, c1], ws.Cells[r2, c2]];
            r.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, weight);
        }
