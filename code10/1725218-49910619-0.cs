    string want = Console.ReadLine();
    if (Gems.Contains(want))
    {
        Console.WriteLine("Your wedding ring will feature your selection: " + want);
    }
    else 
    {
        Console.WriteLine("Im sorry that was not a valid selection.");               
    }
