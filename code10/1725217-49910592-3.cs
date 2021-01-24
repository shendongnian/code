    List<string> Gems = new List<string>();
    Gems.Add("ruby");
    Gems.Add("emerald");
    Gems.Add("topaz");
    Gems.Add("diamond");
    Gems.Add("pearl");
    Gems.Add("infinity stone");
    Console.WriteLine("Please enter the type of gem you want on your wedding ring: ");
    string want = Console.ReadLine();
    
    if(Gems.Contains(want))
        Console.WriteLine("Your wedding ring will feature your selection: " + want);
    else
        Console.WriteLine("Im sorry that was not a valid selection.");
