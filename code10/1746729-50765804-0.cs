        using Excel = Microsoft.Office.Interop.Excel;
        using System.Runtime.InteropServices;
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range, sRange;
        string str;
        int rCnt;
        int cCnt;
        int rw = 0;
        int cl = 0;
        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open("PATH", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("sheetName");
        range = xlWorkSheet.Cells;
        sRange = range.Range["B2", "H10"];
        rw = sRange.Rows.Count;
        cl = sRange.Columns.Count;
        for (rCnt = 1; rCnt <= rw; rCnt++)
        {
            for (cCnt = 1; cCnt <= cl; cCnt++)
            {
                str = ((sRange.Cells[rCnt, cCnt] as Excel.Range).Value2).ToString();
                MessageBox.Show(str);
            }
        }
