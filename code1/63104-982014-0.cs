    // using System.Runtime.InteropServices
    
    // Cleanup:
    GC.Collect();
    GC.WaitForPendingFinalizers();
    
    Marshal.ReleaseComObject(cell);
    
    ppPres.Close();
    Marshal.ReleaseComObject(ppPres);
    
    ppApp.Quit();
    Marshal.ReleaseComObject(ppApp);
