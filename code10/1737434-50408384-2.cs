    class Program
    {
        static void Main(string[] args)
        {
            CommandExit();
            Console.ReadLine();
        }
            private static void CommandExit()
        {
            var countdown = 5;
            Console.WriteLine("Thank you for your input!");
            Console.WriteLine("The programm will now close. \r\n");
            Console.WriteLine("Press any Key to interrupt the closing process.");
            var myTimer = new Timer(state =>
            {
                Console.WriteLine("Program is closing in: '{0}' ", countdown);
                countdown--;
                if (countdown <= 0)
                {
                    Environment.Exit(0);
                }
            }, null, 0, 1000);
            Console.ReadKey();
            myTimer.Change(Timeout.Infinite, Timeout.Infinite);          
        }
    }
