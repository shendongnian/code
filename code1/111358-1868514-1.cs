    CultureInfo info = CultureInfo.GetCultureInfo("en-US");
    decimal m = 1500.00m;
    string s = m.ToString("G", info).Replace(".", String.Empty));
    Console.WriteLine(s); // outputs "150000"
    m = 1500.0m;
    string s = m.ToString("G", info).Replace(".", String.Empty));
    Console.WriteLine(s); // outputs "15000"
    m = 1500.000m;
    string s = m.ToString("G", info).Replace(".", String.Empty));
    Console.WriteLine(s); // outputs "1500000"
    m = 1500.001m;
    string s = m.ToString("G", info).Replace(".", String.Empty));
    Console.WriteLine(s); // outputs "1500001"
    m = 1500.00000000000000000000001m;
    string s = m.ToString("G", info).Replace(".", String.Empty));
    Console.WriteLine(s); // outputs "150000000000000000000000001"
