    using System.Diagnostics;
    [WebMethod]
    public string GetProcessName()
    {
       string processTitle = string.Empty;
       Process process = Process.GetProcessById(1428);
       if(process != null)
       {     
          processTitle = process.MainWindowTitle;
       }
       return processTitle;
    }
