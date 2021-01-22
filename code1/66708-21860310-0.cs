    public static IEnumerable<int> GeneratePrimes()
    {
       return Range(2).Where(candidate => Range(2, (int)Math.Sqrt(candidate)))
                                         .All(divisor => candidate % divisor != 0));
    }
