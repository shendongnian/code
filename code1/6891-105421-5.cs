    public enum Suits
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds,
        NumSuits
    }
    
    public void PrintAllSuits()
    {
        foreach (var suit in Enum.GetValues(typeof(Suits)))
        {
            System.Console.WriteLine(suit.ToString());
        }
    }
