    public static void Main()    
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();
            // Evaluate Input Key
            if (int.TryParse(keyInfo.Key, int i out)
            {
                // do something
            }
            else { // do something else }
        }
        while (keyInfo.Key != ConsoleKey.Escape);
    }
