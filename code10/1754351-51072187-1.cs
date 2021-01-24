    static void Main(string[] args)
    {
        string s = "Console Task Manager v1.0.0";
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
        Console.WriteLine(s);
        Console.WriteLine("Type 'exit' for close this application.");
        Console.WriteLine("\nPlease type the process what are you looking for:");
        while (Console.ReadLine() != "exit") // readline 1
        {
            GetProcesses();
        }
    }
    static void GetProcesses()
    {
        Process[] processes = Process.GetProcessesByName(Console.ReadLine()); // readline 2
        foreach(Process process in processes)
        {
            Console.WriteLine("ID: " + process.Id + " | Name: " + process.ProcessName);
            //process.Kill();
        }
    }
