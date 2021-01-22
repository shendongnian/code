    double value = 999.56m;
    CultureInfo info = CultureInfo.GetCultureInfo("en-US");
    string s = value.ToString("0000000000.0000", info).Replace(
        info.NumberFormat.NumberDecimalSeparator,
        String.Empty)
    Console.WriteLine(s); // displays "00000009995600"
