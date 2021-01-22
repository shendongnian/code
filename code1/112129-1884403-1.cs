    // avoid whacked out cultures
    double value = 999.56m;
    CultureInfo info = CultureInfo.GetCultureInfo("en-US");
    string s = (10000 * value).ToString("00000000000000", info));
    Console.WriteLine(s); // displays "00000009995600"
