    [Test]
    public void And_PredicatesAreShortCircuited()
    {
        var predicateNotUsed = true;
        Expression<Func<int, bool>> a = x => false;
        Expression<Func<int, bool>> b = x => NonVoidFail(x);
        var foo = new[] { 1, 2, 3, 4, 5, 6, 7 }
            .Where(a.And(b).Compile())
            .ToArray();
    }
