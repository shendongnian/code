    do
    {
        Console.WriteLine("Please enter your total time parked in hours: Eg 1.5 or 3.0");
        parkTime = decimal.Parse(Console.ReadLine());
        if (parkTime < 1 || parkTime > 24)
        {
            Console.WriteLine("Error – Park Time out of range");
        }
    }
    while (parkTime < 1 || parkTime > 24);
    if (parkTime > 8)
    {
        Console.Write("Total fee is $" + MAX_FEE);
    }
    else
    {
         parkFee = Math.Ceiling(parkTime) * HOURLY_RATE;
         Console.Write("Parking Fee = $" + parkFee);
     }
