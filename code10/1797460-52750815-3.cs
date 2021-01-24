    double[][] testMulti = 
        {
            new double[] { 1, 2, 3, 4 },
            new double[] { 5, 6, 7, 8 },
            new double[] { 9, 9.5f, 10, 11 },
            new double[] { 12, 13, 14.3f, 15 }
        };
    Span<double[]> span = testMulti.AsSpan(2, 1);
    Span<double> slice = span[0].AsSpan(1, 2);
    foreach (double d in slice)
        Console.WriteLine(d);
    slice[0] = 10.5f;
    Console.Write(string.Join(", ", testMulti[2]));
    Console.ReadLine();
