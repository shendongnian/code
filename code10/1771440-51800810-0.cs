    public static int ExecHttp(String strBrowserApp, String strURL, String strSessionName, ref String strMessage)
    {
    int intExitCode = 99;
    try
    {
         strMessage = String.Empty;
         System.Diagnostics.Process.Start(strBrowserApp, "-nomerge " + (String.IsNullOrEmpty(strURL) ? "" : strURL));
         System.Threading.Thread.Sleep(3000);
         System.Diagnostics.Process objProcess = null;
         System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();
         foreach (System.Diagnostics.Process proc in procs.OrderBy(fn => fn.ProcessName))
         {
              if (!String.IsNullOrEmpty(proc.MainWindowTitle) && proc.MainWindowTitle.StartsWith(strSessionName))
              {
                   objProcess = proc;
                   break;
              }
          }
          if (objProcess != null)
          {
              objProcess.WaitForExit();
              intExitCode = 0;
              objProcess.Close();
          }
    }
    catch (Exception ex)
    {
         strMessage = ex.Message;
    }
    }
 
