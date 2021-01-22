    Console.Write("Enter weekly cost: ");
    string input = Console.ReadLine("135"); // 135 is the default. The user can change or press enter to accept
    decimal weeklyCost;
    if ( !Decimal.TryParse(input, out weeklyCost) ) 
        weeklyCost = 135;
