    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pinging....until stop command");
            Thread pinger = new Thread(DoPinging);
            pinger.Start();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "stop")
                    break;
                else if (command.ToLower() == "exit")
                    break;
                Console.WriteLine("Ignoring-> " + command);
            }
            pinger.Abort();
        }
        static void DoPinging() 
        { 
            // here goes the pinging code
        }
    }
