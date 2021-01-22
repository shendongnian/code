    [Test]
    public void CanDoFullOuterJoin()
    {
        var list1 = new[] {"A", "B"};
        var list2 = new[] { "B", "C" };
    
        list1.FullOuterJoin(list2, x => x, x => x, (x1, x2) => (x1 ?? "") + (x2 ?? ""))
             .ShouldCollectionEqual(new [] { "A", "BB", "C"} );
    }
