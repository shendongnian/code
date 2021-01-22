    static void Main(string[] args)
    {
        Console.Write("Working....");
        ConsoleSpinner spin = new ConsoleSpinner();
        spin.Start();
     
        // Do some work...
        spin.Stop(); 
    }
