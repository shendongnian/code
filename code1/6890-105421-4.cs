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
        foreach (string name in Enum.GetNames(typeof(Suits)))
        {
            System.Console.WriteLine(name);
        }
    }
