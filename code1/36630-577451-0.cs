    // This doesn't try to cope with negative numbers :)
    public static IEnumerable<int> DivideEvenly(int numerator, int denominator)
    {
        int rem;
        int div = Math.DivRem(numerator, denominator, out rem);
        for (int i=0; i < denominator; i++)
        {
            yield return i < rem ? div+1 : div;
        }
    }
    Test:
    foreach (int i in DivideEvenly(100, 7))
    {
        Console.WriteLine(i);
    }
