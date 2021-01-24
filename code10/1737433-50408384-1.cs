    class Program
    {
        static void Main(string[] args)
        {
            RunTimer();
            Console.ReadLine();
        }
        static void RunTimer()
        {
            var countdown = 10;
            var myTimer = new Timer(state =>
            {
                Console.WriteLine("Program is closing in: '{0}' ", countdown);
                countdown--;
                if (countdown == 0)
                {
                    Console.WriteLine("Thank you for your input!");
                    Console.WriteLine("The programm will now close. \r\n");
                    Environment.Exit(0);
                }
                if (countdown != null)
                {
                    Console.WriteLine("Press any Key to interrupt the closing process.");
                }
            }, null, 0, 1000);
            if (Console.ReadKey() != null)
            {
                myTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
    
