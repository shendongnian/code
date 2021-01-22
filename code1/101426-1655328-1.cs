    Console.Write("Enter weekly cost: ");
    string input = Console.ReadLine(); 
    decimal weeklyCost;
    if ( !Decimal.TryParse(input, out weeklyCost) ) 
        weeklyCost = 135;
