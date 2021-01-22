    string pattern = "yy/MM/dd HH:mm:ss,fff";
    DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
    dateTimeFormatInfo.FullDateTimePattern = pattern;
    String input = "01/01/01 01:01:01,001 Hello World!";
    DateTime timeStamp = DateTime.MinValue;
    if (!DateTime.TryParseExact(
        String.Join(" ", input.Split().Take(2).ToArray()),
        pattern, dateTimeFormatInfo, DateTimeStyles.AllowInnerWhite, out timeStamp))
    {
        Console.WriteLine("Something sad happened");
    }
    Console.WriteLine(timeStamp);
