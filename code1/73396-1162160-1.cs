    bool isValidColour = false;
    while (!isValidColour)
    {
        Console.WriteLine("Please enter the person's favorite color:");
        string tempColor = Console.ReadLine();
        try
        {
            contact.Favoritecolor = (System.Drawing.KnownColor)(Enum.Parse(typeof(System.Drawing.KnownColor), tempColor));
        isValidColour = true;
        }
        catch
        {
            Console.WriteLine("This is an unknown color. Please enter a known color");
        }
    }
