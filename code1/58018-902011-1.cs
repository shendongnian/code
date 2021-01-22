    public static Object consoleLock = new Object();
    public static void Main(string[] args)
    {
        lock (consoleLock)
        {
            // now nothing can write to the console (if it's trying to lock onto it)
            Console.WriteLine("Please Input Something");
            // read from console
        }
        // now, your separate thread CAN write to the console - without 
        // interrupting your input process
    }
