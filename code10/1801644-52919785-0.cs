    if (sbClass.Length == 0)
    {
         System.Threading.Thread.Sleep(30000);
         foreach (var process in Process.GetProcessesByName("ARS.exe"))
         {
             process.Kill();
         }
    }
    else
    {
         FindMain(handle);
    }
 
