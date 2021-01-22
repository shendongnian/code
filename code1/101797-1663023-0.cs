     GC.Collect();
     GC.WaitForPendingFinalizers();
        
        
     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(range);
     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(sheet);
     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(book);
                        
     WB.Close(false, Type.Missing, Type.Missing);
                        
     Excel.Quit();
     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Excel);
