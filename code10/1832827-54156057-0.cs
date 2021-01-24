    private static void Main()
    {
        foreach (Process item in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine($"{item.ProcessName} started at: {item.StartTime}");
            }
            catch(Exception e)
            {
                WriteColoredLine($"{e.Message}: {item.ProcessName}", ConsoleColor.Red);
            }
        }
        GetKeyFromUser("Done! Press any key to exit...");
    }
    private static void WriteColoredLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
