    static IEnumerable<int> PotentialPrimes() { // fails once int.MaxValue exceeded
        yield return 2;
        yield return 3;
        var pp = 5;
        for (; ; ) {
            yield return pp;
            yield return pp + 2;
            pp += 6;
        }
    }
    public static IEnumerable<int> Primes() {
        return PotentialPrimes().Where(p => {
            var sqrt = (int)Math.Floor(Math.Sqrt(p));
            return !PotentialPrimes().TakeWhile(f => f <= sqrt)
                                     .Any(f => p % f == 0);
        });
    }
    
    public static IEnumerable<int> PrimeFactors(this int n) {
        var maxDivisor = (int)Math.Floor(Math.Sqrt(n));
        var testDivisors = Primes().TakeWhile(pp => pp < maxDivisor);
        foreach (var f in testDivisors)
            for (; n % f == 0; n /= f)
                yield return f;
        if (n != 1)
            yield return n;
    }
