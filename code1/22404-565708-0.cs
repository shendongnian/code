            xlWorkbook.Close(SaveChanges:=False)
            xlApplication.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApplication)
            xlRange = Nothing
            xlWorksheet = Nothing
            xlSheets = Nothing
            xlWorkbook = Nothing
            xlApplication = Nothing
            GC.GetTotalMemory(False)
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.GetTotalMemory(True)
