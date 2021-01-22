    Dictionary<string, string> tests = new Dictionary<string,string>()
    {
        { "yy/MM/dd HH:mm:ss,fff", "01/01/01 01:01:01,001 Hello World!"},
        { "yyyyMMddHHmmssfff", "2009111615413829403 Hello World!"},
        { "d.M.yyyy H:m:s,fff", "8.10.2009 8:17:26,338 Hello World!" }
    };
    foreach(KeyValuePair<string, string> test in tests)
    {
        string pattern = test.Key;
        string format = test.Value;
        DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
        dateTimeFormatInfo.FullDateTimePattern = pattern;
        Console.WriteLine("{0} - {1}", pattern, format);
        DateTime timeStamp = DateTime.MinValue;
        if (pattern.Contains(' ')) // approach 1: split and conquer
        {
            format = String.Join(" ", format
                .Split(" ".ToCharArray())
                .Take(pattern.Count(c => c == ' ') + 1));
        }
        else
        {
            format = format.Substring(0, pattern.Length);
        }
        
        if (!DateTime.TryParseExact(
            format, pattern, dateTimeFormatInfo, 
            DateTimeStyles.AllowWhiteSpaces, out timeStamp))
        {
            Console.WriteLine("\tSomething sad happened");
        }
        else
        {
            Console.WriteLine("\t{0}", timeStamp.ToString(pattern));
        }
    }
    Console.Read();
