    static void Main()
    {
        Random r = new Random();
        bool lucky = false;
        int maxTries, minValue, maxValue = 0;
        int magical, guess = 0;
        GetInput("Enter number of tries: ", out maxTries);
        GetInput("Enter minimum number : ", out minValue);
        GetInput("Enter maximum number : ", out maxValue);
        magical = r.Next(minValue, maxValue); // only once
        for (int i = 1; i <= maxTries; i++)
        {
            GetInput("Enter your guess : ", out guess);
            if (guess == magical)
            {
                lucky = true;
                break;
            }
        }
        Console.WriteLine("you.Lucky = {0};", lucky);
        Console.ReadLine();
    }
    static void GetInput(string text, out int variable)
    {
        do Console.Write(text);          // avoing stackoverflow.com scroll
        while (!Int32.TryParse(Console.ReadLine(), out variable));
    }
