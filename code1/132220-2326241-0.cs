    string testValue = "10/11/12";
    DateTime result;
    string[] fmts = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
    if (DateTime.TryParseExact(testValue, fmts, CultureInfo.CurrentCulture,
       DateTimeStyles.AssumeLocal, out result))
    {
       Console.WriteLine(result.ToLongDateString());
    }
