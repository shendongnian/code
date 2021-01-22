                workbook.Close(true, null, null);
                excelApp.Quit();
                if (newSheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(newSheet);
                }
                if (rangeSelection != null)
                {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rangeSelection);
                }
                if (sheets != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                }
                if (workbook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                newSheet = null;
                rangeSelection = null;
                sheets = null;
                workbook = null;
                excelApp = null;
                GC.Collect();
