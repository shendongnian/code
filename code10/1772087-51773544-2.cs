        public static int FindFirstCellInExcelRow(string filePath, int rowNum)
        {
            Excel.Application xlApp = null;
            Excel.Workbook wkBook = null;
            Excel.Worksheet wkSheet = null;
            Excel.Range range = null;
            try
            {
                xlApp = new Excel.Application();
                wkBook = xlApp.Workbooks.Open(filePath);
                wkSheet = wkBook.ActiveSheet;
                range = wkSheet.Cells[rowNum, 1].EntireRow;
                if (range.Cells[1, 1].Value != null)
                {
                    return range.Cells[1, 1].Column;
                }
                var result = range.Find(What: "*", After: range.Cells[1, 1], LookAt: Excel.XlLookAt.xlPart, LookIn: Excel.XlFindLookIn.xlValues, SearchOrder: Excel.XlSearchOrder.xlByColumns, SearchDirection: Excel.XlSearchDirection.xlNext, MatchByte: false, MatchCase: false);
                int colIdx = result?.Column ?? 0; // return 0 if no cell in row contains value
                return colIdx;
            }
            finally
            {
                wkBook.Close();
                Marshal.ReleaseComObject(xlApp);
                Marshal.ReleaseComObject(wkBook);
                Marshal.ReleaseComObject(wkSheet);
                Marshal.ReleaseComObject(range);
                xlApp = null;
                wkBook = null;
                wkSheet = null;
                range = null;
            }
        }
