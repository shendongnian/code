    char input;
    bool IsValid = char.TryParse(Console.ReadLine().ToUpper(), out input);
    if (IsValid) 
    {
        Console.WriteLine("You entered the following char: " + input);
    }
