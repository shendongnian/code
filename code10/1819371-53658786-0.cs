    int num1;
    string input = Console.ReadLine();
    if(!int.TryParse(input, out num1))
    {
        Console.WriteLine("that's not a valid integer");
    }
