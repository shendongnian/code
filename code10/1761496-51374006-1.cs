        string[] sizeOptions = { "6-inches", "Footlong"};
        Console.WriteLine(); //Line 12
        Console.WriteLine("Choose a bread size."); //Line 13
        Console.WriteLine("[ ]" + sizeOptions[0]); //Line 14
        Console.WriteLine("[ ]" + sizeOptions[1]); //Line 15
        Row = 14;
        int currentSize = GetOption(Row, sizeOptions);
        Console.SetCursorPosition(0, 16);
        string size = sizeOptions[currentSize];
