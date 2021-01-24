    string value = Console.ReadLine();
    
    if(!int.TryParse(value, out var num))
    {
        Console.WriteLine("You had one job!");
    }
    else if (num == 9)
    {
        Console.WriteLine("Ooh my number is 9");
    }
