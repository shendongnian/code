    class Program
    {
        static ThreadStart ThreadStart = new ThreadStart(Counter);
        static Thread Thread = new Thread(ThreadStart)
        {
            Priority = ThreadPriority.Highest
        };
        static void Main(string[] args)
        {
            Console.WriteLine("INSTRUCTIONS - You have 30 seconds to answer each question correctly, once you get the question right the next question will appear," +
            "if you get a question wrong the console will display INCORRECT and you will have until the end of the 30 seconds to answer it correctly.");
            //These are the instructions
           
            Thread.Start();
            
            q1();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        static Stopwatch timer = Stopwatch.StartNew();
        static void Counter()
        {
            if(timer.ElapsedMilliseconds < 30000)
            {
                Thread.Sleep(1000);
                Counter();
            }
            else
            {
                Console.WriteLine("Too late");
                Environment.Exit(0);
            }
        }
        static void q1() //Return type is a string as a string prompting the user will ask them to try again
        {
            Console.WriteLine("1+1"); //This is the question
            int answer = Convert.ToInt32(Console.ReadLine());// Can't apply int to a readline, so convert the useres input to an int so you can apply an int variable
            
            if (answer == 2) //If the users input is equal to 2 
            {
                Console.WriteLine("Correct");//Tells the user that they are correct
                Thread.Abort();
            }
            else
            {
                Console.WriteLine("Try again");
                q1();
            }
        }
    }
