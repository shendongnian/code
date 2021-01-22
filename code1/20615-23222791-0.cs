    string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
    
    foreach (string m in monthNames) // writing out
    {
        Console.WriteLine(m);
    }
