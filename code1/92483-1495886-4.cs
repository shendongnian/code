    float CalculateBinomial(int n, int k)
    {
        var numerator = new List<int>();
        var denominator = new List<int>();
        var denominatorOld = new List<int>();
        // again ignore the k! common terms
        for (int i = k + 1; i <= n; i++)
            numerator.Add(i);
        for (int i = 1; i <= (n - k); i++)
        {
            denominator.AddRange(SplitIntoPrimeFactors(i));
        }
        // remove all common factors
        int remainder;                
        for (int i = 0; i < numerator.Count(); i++)
        {
            for (int j = 0; j < denominator.Count() 
                && numerator[i] >= denominator[j]; j++)
            {
                if (denominator[j] > 1)
                {
                    int result = Math.DivRem(numerator[i], denominator[j], out remainder);
                    if (remainder == 0)
                    {
                        numerator[i] = result;
                        denominator[j] = 1;
                    }
                }
            }
        }
        float denominatorResult = 1;
        float numeratorResult = 1;
        denominator.RemoveAll(x => x == 1);
        numerator.RemoveAll(x => x == 1);
        denominator.ForEach(d => denominatorResult = denominatorResult * d);
        numerator.ForEach(num => numeratorResult = numeratorResult * num);
        return numeratorResult / denominatorResult;
    }
    static List<int> Primes = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 
        23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
    List<int> SplitIntoPrimeFactors(int x)
    {
        var results = new List<int>();
        int remainder = 0;
        int i = 0;
        while (!Primes.Contains(x) && x != 1)
        {
            int result = Math.DivRem(x, Primes[i], out remainder);
            if (remainder == 0)
            {
                results.Add(Primes[i]);
                x = result;
                i = 0;
            }
            else
            {
                i++;
            }
        }
        results.Add(x);
        return results;
    }
