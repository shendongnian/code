    Dictionary<string, string> tests = new Dictionary<string,string>()
    {
        { "yy/MM/dd HH:mm:ss,fff", "01/01/01 01:01:01,001 Hello World!"},
        { "yyyyMMddHHmmssfff", "2009111615413829403 Hello World!"}
    };
    foreach(KeyValuePair<string, string> test in tests)
    {
        string pattern = test.Key;
        string input = test.Value;
        DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
        dateTimeFormatInfo.FullDateTimePattern = pattern;
        DateTime timeStamp = DateTime.MinValue;
        if (!DateTime.TryParseExact(
            input.Substring(0, pattern.Length),
            pattern, dateTimeFormatInfo, DateTimeStyles.None, out timeStamp))
        {
            Console.WriteLine("Something sad happened");
        }
        Console.WriteLine(timeStamp.ToString(pattern));
    }
    Console.Read();
