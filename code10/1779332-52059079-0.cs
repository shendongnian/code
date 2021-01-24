    using Excel = Microsoft.Office.Interop.Excel; //you should add the reference to that library for it to work
    public Tuple<int, int> search(string Providedvalue)
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;
        string str;
        int rCnt;
        int cCnt;
        int rw = 0;
        int cl = 0;
        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open("path/exemple.xlsx", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        range = xlWorkSheet.UsedRange;
        rw = range.Rows.Count;
        cl = range.Columns.Count;
        bool found = false;
        for (rCnt = 1; rCnt <= rw && found == false; rCnt++)
        {
                for (cCnt = 1; cCnt <= cl && found == false; cCnt++)
                {
                    dynamic x = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    str = x.ToString();
                    if (Providedvalue == str)
                    {
                        int line = rCnt;
                        int column = cCnt;
                        return new Tuple<int, int>(line, column);
                    }
                }
        }
        return null;
    }
