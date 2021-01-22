            Excel.Application excelApplication;
            Excel.Worksheet excelWorksheet;
            Excel.Workbook excelWorkbook;
            Excel.Range range;
            excelApplication = new Excel.Application();
            excelWorkbook = (Excel.Workbook)(excelApplication.Workbooks.Open(
                <FILENAME>,
                Type.Missing, true, Type.Missing, Type.Missing, Type.Missing,
                true, Type.Missing, Type.Missing, false, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing));
            excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets[<WORKSHEETNAME>];
