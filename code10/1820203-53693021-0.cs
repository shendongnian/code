    static int SumOfDigits(int n)
    {
        var current = n;
        var acc = 0;
        while (current > 0)
        {
            acc += current % 10;
            current /= 10;
        }
        return acc;
    }
    //Current implementation only works for positive n and b
    //Easy to make it work with negative values, only need to
    //perform some checks in absolute values.
    static bool TryFindExponent(int n, int b, out int e)
    {
        e = 0;
        if (b == 0 || n == 0)
            return false;
        //Check in abs if negative inputs are expected
        if (b == 1 &&
            n != 1)
            return false;
        var acc = 1L;
        do
        {
            e += 1;
            acc *= b;
        } while (acc < n) //check in abs if negative 
                          //numbers are expected;
        if (acc == n)
            return true;
        return false;
    }
    static void Main(string[] args)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 1; i < int.MaxValue; i++)
        {
            var b = SumOfDigits(i);
            if (TryFindExponent(i, b, out var e))
            {
                Console.WriteLine($"{i} = {b}^{e}");
            }
        }
        sw.Stop();
        Console.WriteLine($"Finished in {sw.ElapsedMilliseconds/1000.0} seconds.");
    }
