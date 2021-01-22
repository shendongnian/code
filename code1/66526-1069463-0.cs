    private bool GenerateDailyProposalsReport(ScheduledReport report)
    {
        Excel.Application xl = null;
        Excel.Workbooks wBooks = null;
        Excel.Workbook wBook = null;
        Excel.Worksheet wSheet = null;
        Excel.Range xlrange = null;
        Excel.Range xlcell = null;
    
        xl = new Excel.Application();
        wBooks = xl.Workbooks;
        wBook = wBooks.Open(@"DailyProposalReport.xls", false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        wSheet = wBook.ActiveSheet;
        xlrange = wSheet.Cells;
        xlcell = xlrange[2, 1] as Excel.Range;
    
        xlcell.Value2 = "fullname";
        Marshal.ReleaseComObject(xlcell);
        Marshal.ReleaseComObject(xlrange);
        Marshal.ReleaseComObject(wSheet);
        wBook.Close(true, @"c:\temp\DailyProposalReport.xls", Type.Missing);
        Marshal.ReleaseComObject(wBook);
        Marshal.ReleaseComObject(wBooks);
        xl.Quit();
        Marshal.ReleaseComObject(xl);
        return true;
    }
