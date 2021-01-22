    [Test]
    public void Test()
    {
        var strings = new object [] {"1", "2", "woot", "3", Guid.NewGuid()}.AsQueryable();
        var ints = strings.Select(ExpressionHelper.TryDefaultExpression<object, int>(x => Convert.ToInt32(x), 0));
        Assert.IsTrue(ints.SequenceEqual(new[] {1, 2, 0, 3, 0}));
    }
