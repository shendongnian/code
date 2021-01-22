    static void Main(string[] args)
    {
       if (args.Contains(StartProcessesSwitch))
          StartProcesses(GetFileWithArgs(args))
       else
          WriteArgsToFile();
          //Run Program normally
    }
    void button_click(object sender, ButtonClickEventArgs e)
    {
       ShutDownAllMyProcesses()
    }
    
    void ShutDownAllMyProcesses()
    {
       List<Process> processes = GetMyProcesses();
       foreach (Process p in processes)
       {
          if (p != Process.GetCurrentProcess())
             p.Kill(); //or whatever you need to do to close
       }
       ProcessStartInfo psi = new ProcessStartInfo();
       psi.Arguments = CreateArgsWithFile();
       psi.FileName = "<your application here>";
       Process p = new Process();
       p.StartInfo = psi;
       p.Start();
       CloseAppplication();
    }
