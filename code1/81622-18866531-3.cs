    [Test]
    // normal cases
    [TestCase(3, 5, 1, 3, 4)]
    [TestCase(0, 5, 1, 0, 4)]
    [TestCase(3, null, 1, 3, 9)]
    [TestCase(0, null, 1, 0, 9)]
    [TestCase(null, null, 1, 0, 9)]
    [TestCase(0, 10, 1, 0, 9)]
    [TestCase(0, int.MaxValue, 1, 0, 9)]
    [TestCase(-1, null, 1, 9, 9)]
    [TestCase(-2, null, 1, 8, 9)]
    [TestCase(0, -2, 1, 0, 7)]
    // corner cases
    [TestCase(0, 0, 1, null, null)]
    [TestCase(3, 5, 2, 3, 3)]
    [TestCase(3, 6, 2, 3, 5)]
    [TestCase(100, int.MaxValue, 1, null, null)]
    [TestCase(int.MaxValue, 1, 1, null, null)]
    [TestCase(-11, int.MaxValue, 1, null, null)]
    [TestCase(-6, -5, 1, 4, 4)]
    [TestCase(-5, -6, 1, null, null)]
    [TestCase(-5, -5, 1, null, null)]
    [TestCase(0, -10, 1, null, null)]
    [TestCase(0, -11, 1, null, null)]
    [TestCase(null, null, 100, 0, 0)]
    // -ve step
    [TestCase(null, null, -1, 9, 0)]
    [TestCase(-7, -5, -1, null, null)]
    [TestCase(-5, -7, -1, 5, 4)]
    [TestCase(-5, -7, -2, 5, 5)]
    [TestCase(-7, null, -1, 3, 0)]
    public void Slice01(int? s, int? e, int i, int? first, int? last)
    {
        var a = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var slice = a.Slice(start: s, end: e, step: i).ToArray();
        Print(slice);
        if (first.HasValue)
        {
            Assert.AreEqual(first, slice.First());
        }
        if (last.HasValue)
        {
            Assert.AreEqual(last, slice.Last());
        }
    }
