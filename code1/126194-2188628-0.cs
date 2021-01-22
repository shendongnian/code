    DateTime dt;
    if (DateTime.TryParseExact("20100202", "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
       Console.WriteLine(dt.ToString());
    }
