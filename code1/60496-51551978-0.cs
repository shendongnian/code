    public enum Suit : int
    {
        Spades = 0,
        Hearts = 1,
        Clubs = 2,
        Diamonds = 3
    }
    Console.WriteLine((int)(Suit)Enum.Parse(typeof(Suit), "Clubs"));
    
    //from int
    Console.WriteLine((Suit)1);
    //From number you can also
    Console.WriteLine((Suit)Enum.ToObject(typeof(Suit), 1));
    
    if (typeof(Suit).IsEnumDefined("Spades"))
    {
        var res = (int)(Suit)Enum.Parse(typeof(Suit), "Spades");
        Console.Out.WriteLine("{0}", res);
    }
