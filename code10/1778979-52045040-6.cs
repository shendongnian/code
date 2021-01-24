    public void GetPlayerInfo()
    {
        Console.Write("Enter Name : ");
        Name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Pick a Color : ");
        Console.WriteLine("1 : Red");
        Console.WriteLine("2 : Blue");
        Console.WriteLine("3 : Green");
        var key = Console.ReadLine();
        switch (key)
        {
            case "1":
                Color = ConsoleColor.Red;
                break;
            case "2":
                Color = ConsoleColor.Blue;
                break;
            case "3":
                Color = ConsoleColor.Green;
                break;
            default:
                Color = ConsoleColor.White;
                break;
        }
        Console.WriteLine();
    }
