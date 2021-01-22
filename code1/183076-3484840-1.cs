    public static double SumExponents(double x, int n)
    {
        return Enumerable.Range(1, n)
                         .Select(i => Math.Pow(x, i))
                         .Sum();
    }
   
