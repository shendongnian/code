    [Test]
    public void GetEnumerator_FirstFifteenNumbers_AreCorrect()
    {
        IEnumerable weak = new FibonacciSequence();
        var sequence = weak.Cast<int>().Take(15).ToArray();
        CollectionAssert.AreEqual(sequence, 
            new[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610});
    }
