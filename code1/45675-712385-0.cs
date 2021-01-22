    static void Main(string[] args)
    {
      var haveToUpdate = ...;
      if (haveToUpdate)
      {
        Process.Start("update.exe");
        Environment.Exit(0);
      }
    }
    static void Main(string[] args)
    {
      var processes = Process.GetProcessesByName("program.exe");
      if (processes.Length > 1)
        throw new Exception("More than one program.exe running");
      else if (processes.Length == 0)
        Update();
      else
        processes[0].Exited += new EventHandler(Program_Exited);
    }
    static void Program_Exited(object sender, EventArgs e)
    {
      Update();
    }
    static void Update()
    {
      // ...
    }
