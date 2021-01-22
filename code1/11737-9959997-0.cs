            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Sheets xlSheets = null;
            Excel.Worksheet xlNewSheet = null;
            string worksheetName ="Sheet_Name";
            object readOnly1 = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            
                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                        return;
                    // Uncomment the line below if you want to see what's happening in Excel
                    // xlApp.Visible = true;
                    xlWorkbook = xlApp.Workbooks.Open(@"C:\Book1.xls", missing, readOnly1, missing, missing, missing, missing, missing, missing, missing, missing, isVisible, missing, missing, missing);
                    xlSheets = (Excel.Sheets)xlWorkbook.Sheets;
                    // The first argument below inserts the new worksheet as the first one
                    xlNewSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheet.Name = worksheetName;
                    xlWorkbook.Save();
                    xlWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                    xlApp.Quit();
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlNewSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    //xlApp = null;
                }
