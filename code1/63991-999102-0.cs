    private static void Test()
    {
        string[] test = new string[3] { "dog", "cat", "mouse" };
        foreach (var x in Subsets(test))
            Console.WriteLine("[{0}]", string.Join(",", x));
    }
    public static IEnumerable<T[]> Subsets<T>(T[] source)
    {
        if (source == null || source.Length == 0) yield break;
        int max = 1 << source.Length;
        for (int i = 0; i < max; i++)
        {
            T[] combination = new T[source.Length];
            for (int j = 0; j < source.Length; j++)
            {
                int tailIndex = source.Length - j - 1;
                combination[tailIndex] =
                    ((i & (1 << j)) != 0) ? source[tailIndex] : default(T);
            }
            yield return combination;
        }
    }
