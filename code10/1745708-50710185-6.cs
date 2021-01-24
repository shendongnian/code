    private static void Main()
    {
        foreach (string name in GetEmployeeFirstAndLastNames())
        {
            Console.WriteLine(name);
        }
            
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
