    String s = "8:00 AM";
    DateTime dt = DateTime.Parse(s);
    if (dt < DateTime.Parse("9:00 AM"))
    {
        Console.WriteLine("Before");
    }
    else if (dt <= DateTime.Parse("6:00 PM"))
    {
        Console.WriteLine("Between");
    }
    else
    {
        Console.WriteLine("After");
    }
