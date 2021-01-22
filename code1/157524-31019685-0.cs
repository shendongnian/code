     public static void AutoFitExcelSheets()
        {
            Microsoft.Office.Interop.Excel.Application _excel = null;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = null;
            try
            {
                string ExcelPath = ApplicationData.PATH_EXCEL_FILE;
                _excel = new Microsoft.Office.Interop.Excel.Application();
                _excel.Visible = false;
                object readOnly = false;
                object isVisible = true;
                object missing = System.Reflection.Missing.Value;
                excelWorkbook = _excel.Workbooks.Open(ExcelPath,
                       0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                       true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                foreach (Microsoft.Office.Interop.Excel.Worksheet currentSheet in excelSheets)
                {
                    string Name = currentSheet.Name;
                    Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(Name);
                    Microsoft.Office.Interop.Excel.Range excelCells =
    (Microsoft.Office.Interop.Excel.Range)excelWorksheet.get_Range("A3", "K3");
                    excelCells.Columns.AutoFit();
                }
            }
            catch (Exception ex)
            {
                ProjectLog.AddError("EXCEL ERROR: Can not AutoFit: " + ex.Message);
            }
            finally
            {
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                releaseObject(excelWorkbook);
                releaseObject(_excel);
            }
        }
