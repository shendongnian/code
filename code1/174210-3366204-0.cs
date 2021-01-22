        public static void ExportToExcel<T>(IEnumerable<T> exportData)
        {
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            PropertyInfo[] pInfos = typeof(T).GetProperties();
            if (pInfos != null && pInfos.Count() > 0)
            {
                int iCol = 0;
                int iRow = 0;
                foreach (PropertyInfo eachPInfo in pInfos.Where(W => W.CanRead == true))
                {
                    // Add column headings...
                    iCol++;
                    excel.Cells[1, iCol] = eachPInfo.Name;
                }
                foreach (T item in exportData)
                {
                    iRow++;
                    // add each row's cell data...
                    iCol = 0;
                    foreach (PropertyInfo eachPInfo in pInfos.Where(W => W.CanRead == true))
                    {
                        iCol++;
                        excel.Cells[iRow + 1, iCol] = eachPInfo.GetValue(item, null);
                    }
                }
                // Global missing reference for objects we are not defining...
                object missing = System.Reflection.Missing.Value;
                // If wanting to Save the workbook...   
                string filePath = System.IO.Path.GetTempPath() + DateTime.Now.Ticks.ToString() + ".xlsm";
                workbook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled, missing, missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
                // If wanting to make Excel visible and activate the worksheet...
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                excel.Rows.EntireRow.AutoFit();
                excel.Columns.EntireColumn.AutoFit();
                ((Excel._Worksheet)worksheet).Activate();
            }
        }
