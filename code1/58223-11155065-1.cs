    System.Diagnostics.Process loProcess = System.Diagnostics.Process.GetCurrentProcess();
    try
    {
         loProcess.MaxWorkingSet = (IntPtr)((int)loProcess.MaxWorkingSet - 1);
         loProcess.MinWorkingSet = (IntPtr)((int)loProcess.MinWorkingSet - 1);
    }
    catch (System.Exception)
    {
         loProcess.MaxWorkingSet = (IntPtr)((int)1413120);
         loProcess.MinWorkingSet = (IntPtr)((int)204800);
    }
               
