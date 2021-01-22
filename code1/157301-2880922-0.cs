    char a = 'å';
    char b = 'ä';
    // outputs -1:
    Console.WriteLine(String.Compare(
      a.ToString(),
      b.ToString(),
      CultureInfo.GetCultureInfo("sv-SE"),
      CompareOptions.IgnoreCase
    ));
    // outputs 1:
    Console.WriteLine(String.Compare(
      a.ToString(),
      b.ToString(),
      CultureInfo.GetCultureInfo("en-GB"),
      CompareOptions.IgnoreCase
    ));
