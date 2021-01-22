    public List<int> GeneratePrimes(int n) {
        var r = from i in Enumerable.Range(2, n - 1).AsParallel()
                where Enumerable.Range(2, (int)Math.Sqrt(i)).All(j => i % j != 0)
                select i;
        return r.ToList();
    }
