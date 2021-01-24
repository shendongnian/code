    public static double[] ArrayOfDouble(int scale)
    {
       return Enumerable.Range(1, scale)
                        .Select(x =>_rand.NextDouble())
                        .ToArray();
    }
