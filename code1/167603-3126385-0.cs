    using System;
    
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("What is your name?  ");
                string name = Console.ReadLine();
    
                bool validInput = false;
                int inputDays = 0;
                int actualDays = 7;
    
                while (!validInput)
                {
                    Console.Write("How many days are in a week?  ");
                    string response = Console.ReadLine();
                    validInput = int.TryParse(response, out inputDays);
                }
    
                Console.WriteLine("{0}, you said there are {1} days in a week. This is {2}.", name, inputDays, inputDays == actualDays);
                Console.ReadKey();
            }
        }
    }
