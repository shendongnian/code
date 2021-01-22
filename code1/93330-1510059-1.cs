    // Helper extension method
    public static IEnumerable AsWeakEnumerable(this IEnumerable source)
    {
        foreach (object o in source)
        {
            yield return o;
        }
    }
    ...
    [Test]
    public void GetEnumerator_FirstFifteenNumbers_AreCorrect()
    {
        IEnumerable weak = new FibonacciSequence().AsWeakEnumerable();
        var sequence = weak.Cast<int>().Take(15).ToArray();
        CollectionAssert.AreEqual(sequence, 
            new[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610});
    }
