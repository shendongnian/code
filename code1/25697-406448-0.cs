    static IEnumerable<int> Fibonacci()
    {
        int n = 0, m = 1;
        yield return 0;
        yield return 1;
        while (true)
        {
            int tmp = n + m;
            n = m;
            m = tmp;
            yield return m;
        }
    }
    static void Main()
    {
        foreach (int i in Fibonacci().Take(10))
        {
            Console.WriteLine(i);
        }
    }
