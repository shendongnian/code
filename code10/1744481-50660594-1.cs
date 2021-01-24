    static Dictionary<int, int> results = new Dictionary<int, int>();
    public static int SomeAlgo(int n)
    {
        int result = 0;
        if (results.TryGetValue(n, out result))
        {
            return result;
        }
        if ((n == 0) || (n == 1))
        {
            return n;
        }
        result = SomeAlgo(n - 1) + SomeAlgo(n - 2);
        results.Add(n, result);
        return result;
    }
