    double[][] testMulti = 
        {
            new double[] { 1, 2, 3, 4 },
            new double[] { 5, 6, 7, 8 },
            new double[] { 9, 9.5f, 10, 11 },
            new double[] { 12, 13, 14.3f, 15 }
        };
    double[] testArray = { 1, 2, 3, 4 };
    string testString = "Hellow world";
    Span<double[]> span = testMulti.AsSpan(2, 1);
    Span<double> slice = span[0]
        .AsSpan()
        .Slice(1, 2);
    foreach (double d in slice)
        Console.WriteLine(d);
    
    Console.ReadLine();
