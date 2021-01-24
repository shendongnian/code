    /// <summary>
    /// Field that indicates whether or not the program should keep running.
    /// </summary>
    static bool keepRunning = true;
    static void Main(string[] args)
    {
      string s = "Console Task Manager v1.0.0";
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
      Console.WriteLine(s);
      Console.WriteLine("Type 'exit' for close this application.");
      Console.WriteLine("\nPlease type the process what are you looking for:");
      do
      {
        string lastCommand = Console.ReadLine();
        ProcessCommand(lastCommand);
      } while (keepRunning);
    }
    /// <summary>
    /// Processes a command we've received.
    /// </summary>
    /// <param name="command">The command that was entered.</param>
    static void ProcessCommand(string command)
    {
      if (string.IsNullOrEmpty(command))
      {
        return;
      }
      // A command might have one or more parameters, these will be separated
      // by spaces (i.e. "kill 12345").
      string[] commandParts = command.Split(' ');
      // Process each command we know about.
      if (commandParts[0] == "exit")
      {
        keepRunning = false;
      }
      else if (commandParts[0] == "kill")
      {
        // This command needs 1 parameter.
        if (commandParts.Length < 2)
        {
          Console.WriteLine("kill command requires process name or ID");
          return;
        }
        // Try checking if the second value can be parsed to an integer. If so
        // we'll assume it's the process ID to kill. Otherwise, we'll try to 
        // kill the process by that name.
        int id;
        if (int.TryParse(commandParts[1], out id))
        {
          KillProcessByID(id);
        }
        else
        {
          KillProcessByName(commandParts[1]);
        }
      }
      // More commands can be added here.
      // This isn't a known command.
      else
      {
        Console.WriteLine("Unknown command \"" + command + "\"");
      }
    }
    static void KillProcessByName(string processName)
    {
      Process[] processes = Process.GetProcessesByName(processName);
      foreach (Process process in processes)
      {
        Console.WriteLine("ID: " + process.Id + " | Name: " + process.ProcessName);
        //process.Kill();
      }
    }
    static void KillProcessByID(int processID)
    {
      Process process = Process.GetProcessById(processID);
      if (process != null)
      {
        Console.WriteLine("ID: " + process.Id + " | Name: " + process.ProcessName);
        //process.Kill();
      }
    }
