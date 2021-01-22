    double original = 12.123456789;  
  
    double truncated = Truncate(original, 2);  
  
    Console.WriteLine(truncated.ToString());
    // or 
    // Console.WriteLine(truncated.ToString("0.00"));
    // or 
    // Console.WriteLine(Truncate(original, 2).ToString("0.00"));
    public static double Truncate(double value, int precision)
    {
        return Math.Truncate(value * Math.Pow(10, precision)) / Math.Pow(10, precision);
    }
