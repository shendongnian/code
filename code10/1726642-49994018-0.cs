    double totDays = 39448;
    DateTime inDate = new DateTime(1900, 1, 1);
    DateTime CalculatedDate = inDate.AddDays(totDays);
    Console.WriteLine(" Start date: " + inDate.ToLongDateString());
    Console.WriteLine("   Add days: " + totDays);
    Console.WriteLine("Result date: " + CalculatedDate.ToLongDateString());
    Console.WriteLine(" FromOADate: " + DateTime.FromOADate(totDays).ToLongDateString());
    Console.ReadLine();
