    static void Main(string[] args)
    {
        var x = new double[] { 0.0, 1.0, 2.0, double.NaN, 4.0, 5.0 };
        var y = new double[] { 0.5, 1.5, double.PositiveInfinity, 3.5, 4.5, 5.5 };
        // note: using KeyValuePair<double, double> --
        // you could just as easily use your own custom type
        // (probably a simple struct)
        var zipped = x.Zip(y, (a, b) => new KeyValuePair<double, double>(a, b))
            .Where(kvp => IsValid(kvp.Key) && IsValid(kvp.Value))
            .ToList();
        
        foreach (var z in zipped)
            Console.WriteLine("X: {0}, Y: {1}", z.Key, z.Value);
    }
    static bool NoInvalidValues(double value)
    {
        return !double.IsNaN(value) && !double.IsInfinity(value);
    }
    
