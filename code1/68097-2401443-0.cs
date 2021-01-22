        object[,] values = { { 111, 222, 333 }, { 444, 555, 666 }, { 101, 202, 303 }, 
                             { 404, 505, 606 }, { 111, 222, 333 }, { 444, 555, 666 },
                             { 101, 202, 303 }, { 404, 505, 606 } };
        Application excel = new Application();
        Workbook workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Worksheet sheet = (Worksheet)workbook.Worksheets[1];
        int rows = values.GetUpperBound(0) - values.GetLowerBound(0) + 1;
        int cols = values.GetUpperBound(1) - values.GetLowerBound(1) + 1;
        // assign a name to an area of cells and fill it with values
        Range dest = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[rows, cols]);
        dest.Name = "SORUCE_RANGE";
        dest.Value2 = values;
        // assign a name to a single cell
        dest = (Range) sheet.Cells[5, 7];
        dest.Name = "MY_DESTINATION";
        dest.NumberFormatLocal = "TT.MM.JJJJ hh:mm:ss"; //german format syntax
        dest.Value2 = DateTime.Now;
        // clean up (best in finally block)
        workbook.Close(false, null, null);
        excel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
