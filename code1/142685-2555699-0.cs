    static void Main(string[] args)
    {
        Console.WriteLine("Count of arguments: {0}", args.Length);
        int choice = 0;
    
        if (args.Length == 0)
           choice = 1;
        else
           choice = 2;
        Console.WriteLine("Choice now is: {0}", choice);
