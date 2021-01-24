        static void Main(string[] args)
        {
            Random random = new Random();
            while(true)
            {
                String numberDiceString = "";
                int numberDice = 0;
                Console.WriteLine("Enter a number of dice to roll:");
                numberDiceString = Console.ReadLine();
                if (numberDiceString == "quit") { return; }
                int total = 0;
                if (Int32.TryParse(numberDiceString, out numberDice))
                {
                    total = 0;
                    for (int index = 0; index < numberDice; index++)
                    {
                        int DieRoll = random.Next(6) + 1;
                        total += DieRoll;
                    }
                }
                Console.WriteLine(total);
            }            
        }
