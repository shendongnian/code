    BigInteger value = BigInteger.Parse(
        "62FA7AC4" + 
        "2500" + 
         DateTime.Today.ToString("ddMMyyyy"), 
       NumberStyles.HexNumber);
    string result = ToBase36(value);
    BigInteger back = FromBase36(value);
    Console.WriteLine(string.Join(Environment.NewLine, value, result, back));
