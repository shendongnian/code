    var origDt = DateTime.Now;
    var dtStr = origDt.ToString("O");
    var newDt = DateTime.Parse(dtStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
    Console.WriteLine(dtStr);
    if (newDt == origDt)
        Console.WriteLine("Dates equal"); // should be true
    else
        Console.WriteLine("Dates not equal");
