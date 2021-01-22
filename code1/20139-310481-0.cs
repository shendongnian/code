    using System.Diagnostics;
    static void MyFunc()
    {
        Process[] processes = Process.GetProcesses();
        foreach(Process p in processes)
        {
           if (p.MainWindowHandle != 0)
           { // This is a GUI process
           }
           else
           { // this is a non-GUI / invisible process
           }
        }
    }
