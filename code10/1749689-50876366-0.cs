    public static int GetBet(int betAmount)
    {
        Console.Write("How many points do you want to bet? ");
        int bet = int.Parse(Console.ReadLine());
        Console.ReadLine();
        return bet;
    }
