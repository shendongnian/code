    Tag Val = (Tag)9;
    if (Val.HasFlag(Tag.PrimaryNav))
    {
        Console.WriteLine("Primary Nav");
    }
    if(Val.HasFlag(Tag.HomePage))
    {
        Console.WriteLine("Home Page");
    }
