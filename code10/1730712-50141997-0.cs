    static void Main(string[] args)
    {
        Random random = new Random();
        string numberDiceString;
        int numberDice;
        Console.WriteLine("Enter a number of dice to roll:");
        while ((numberDiceString = Console.ReadLine()) != "quit")
        {
            bool parsed = int.TryParse(numberDiceString, out numberDice);
            if (!parsed)
            {
                //Handle the error. The user input was not a number or "quit" word
                break;
            }
            int total = 0;
    
            for (int index = 0; index < numberDice; index++)
            {
                int DieRoll = random.Next(6) + 1;
                total += DieRoll;
            }
    
            Console.WriteLine(total);
            Console.WriteLine("Enter a number of dice to roll:");
        }
    }
