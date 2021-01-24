               System.Runtime.InteropServices.Marshal.ReleaseComObject(startCell );    
               System.Runtime.InteropServices.Marshal.ReleaseComObject(endCell);             
             System.Runtime.InteropServices.Marshal.ReleaseComObject(writeRange);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange );
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange );
                startCell = null;
                endCell = null;
                writeRange = null;
                myExcelApp.Quit();
                           
              System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcelApp);
                myExcelApp = null;
                myExcelWorkbook = null;
                System.GC.Collect();
                GC.WaitForPendingFinalizers();
