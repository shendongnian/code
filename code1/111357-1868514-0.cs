    string separator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.
    decimal m = 1500.00m;
    string s = m.ToString("G", CultureInfo.InvariantCulture)
                .Replace(separator, String.Empty));
    Console.WriteLine(s); // outputs "150000"
    m = 1500.0m;
    s = m.ToString("G", CultureInfo.InvariantCulture)
         .Replace(separator, String.Empty));
    Console.WriteLine(s); // outputs "15000"
    m = 1500.000m;
    s = m.ToString("G", CultureInfo.InvariantCulture)
         .Replace(separator, String.Empty));
    Console.WriteLine(s); // outputs "1500000"
    m = 1500.001m;
    s = m.ToString("G", CultureInfo.InvariantCulture)
         .Replace(separator, String.Empty));
    Console.WriteLine(s); // outputs "1500001"
