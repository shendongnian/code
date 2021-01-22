    class Program
    {
        static int Main(string[] args)
        {
            // Init Code...
            Console.CancelKeyPress += Console_CancelKeyPress;  // Register the function to cancel event
            // I do my stuffs
            
            while ( true )
            {
                // Code ....
                SomePreemptiveCall();  // The loop stucks here wating function to return
                // Code ...
            }
            return 0;  // Never comes here, but...
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Exiting");
            // Termitate what I have to terminate
            Environment.Exit(-1);
        }
    }
