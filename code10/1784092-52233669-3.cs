    public static IEnumerable<T[]> AsBatches<T>(T[] input, int n)
    {
        for (int i = 0, r = input.Length; r > n; r -= n, i += n)
        {
            var result = new T[n];
            Array.Copy(input, i, result, 0, n);
            yield return result;
        }
    }
