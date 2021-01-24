    bool isValidTime = false;
    do
    {
        Console.WriteLine("Please enter your total time parked in hours: Eg 1.5 or 3.0");
        bool parsedOK = decimal.TryParse(Console.ReadLine(), out parkTime);
        isValidTime = parsedOK && parkTime >= 1 && parkTime <= 24;
    }
    while (!isValidTime);
    parkFee = Math.Min(MAX_FEE, Math.Ceiling(parkTime) * HOURLY_RATE);
    Console.Write("Parking Fee = $" + parkFee);
