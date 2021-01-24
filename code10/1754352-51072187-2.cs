    static void Main(string[] args)
    {
        string s = "Console Task Manager v1.0.0";
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
        Console.WriteLine(s);
        Console.WriteLine("Type 'exit' for close this application.");
        Console.WriteLine("\nPlease type the process what are you looking for:");
        string lastCommand = string.Empty;
        do
        {
            lastCommand = Console.ReadLine();
            if (lastCommand != "exit")
            {
                KillProcess(lastCommand);
            }
        } while (lastCommand != "exit");
    }
    static void KillProcess(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        foreach(Process process in processes)
        {
            Console.WriteLine("ID: " + process.Id + " | Name: " + process.ProcessName);
            //process.Kill();
        }
    }
