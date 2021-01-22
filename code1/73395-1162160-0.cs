    try
    {
        contact.Favoritecolor = (System.Drawing.KnownColor)(Enum.Parse(typeof(System.Drawing.KnownColor), tempColor));
    }
    catch
    {
        Console.WriteLine("This is an unknown color. Please enter a known color");
    }
