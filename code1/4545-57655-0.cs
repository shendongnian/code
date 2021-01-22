    class Sample 
    {
        public static void Main() 
        {
        ConsoleKeyInfo cki = new ConsoleKeyInfo();
    
        do {
            Console.WriteLine("\nPress a key to display; press the 'x' key to quit.");
    
    // Your code could perform some useful task in the following loop. However, 
    // for the sake of this example we'll merely pause for a quarter second.
    
            while (Console.KeyAvailable == false)
                Thread.Sleep(250); // Loop until input is entered.
            cki = Console.ReadKey(true);
            Console.WriteLine("You pressed the '{0}' key.", cki.Key);
            } while(cki.Key != ConsoleKey.X);
        }
    }
