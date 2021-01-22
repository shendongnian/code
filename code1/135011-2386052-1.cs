    string str = "Tue Aug 19 15:05:05 +0000 2008";
    string format = "ddd MMM dd HH:mm:ss zzz yyyy";
    DateTime date;
    if (DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture, 
        DateTimeStyles.None, out date))
    {
        Console.WriteLine(date.ToString());
    }
