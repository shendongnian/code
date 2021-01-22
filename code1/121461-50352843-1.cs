    delegate void PrintDelegate(string prompt);
    
    static void PrintSomewhere(PrintDelegate print, string prompt)
    {
        print(prompt);
    }
    
    static void PrintOnConsole(string prompt)
    {
        Console.WriteLine(prompt);
    }
    
    static void PrintOnScreen(string prompt)
    {
        MessageBox.Show(prompt);
    }
    
    static void Main()
    {
        PrintSomewhere(PrintOnConsole, "Press a key to get a message");
        Console.Read();
        PrintSomewhere(PrintOnScreen, "Hello world");
    }
