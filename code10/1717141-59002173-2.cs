    static void Main(string[] args)
    {
        Action<string> action = new Action<string>(Display);
        action("Hello!!!");
        Console.Read(); //Prevents from closing the command line right away.
    }
    
    static void Display(string message)
    {
        Console.WriteLine(message);
    }
