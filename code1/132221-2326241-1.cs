    string testValue = "10.11.12";
    DateTime result;
    CultureInfo ci = CultureInfo.GetCultureInfo("sl-SI");
    string[] fmts = ci.DateTimeFormat.GetAllDateTimePatterns();
    Console.WriteLine(String.Join("\r\n", fmts));
    if (DateTime.TryParseExact(testValue, fmts, ci,
       DateTimeStyles.AssumeLocal, out result))
    {
       Console.WriteLine(result.ToLongDateString());
    }
