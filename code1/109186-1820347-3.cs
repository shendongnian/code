    [Test]
    public void And_PredicatesAreShortCircuited()
    {
        Expression<Func<string, bool>> a = x => false;
        Expression<Func<string, bool>> b = x => x.Length > 10;
        var foo = new[] { null, null }
            .Where(a.And(b).Compile())
            .ToArray();
    }
