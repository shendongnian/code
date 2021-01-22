    using System.Numerics;
    public static IEnumerable<IEnumerable<T>> GetSubsets<T>(IList<T> source)
    {
        BigInteger combinations = BigInteger.One << source.Count;
        for (BigInteger i = 0; i < combinations; i++)
        {
            yield return Enumerable.Range(0, source.Count)
                .Select(j => (i & (BigInteger.One << j)) != 0 ? source[j] : default);
        }
    }
