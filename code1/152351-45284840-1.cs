    [Test]
    public void ShouldMergeInOrderMultipleOrderedListWithDuplicateValues()
    {
        // given
        IEnumerable<IEnumerable<int>> orderedLists = new[]
        {
            new [] {1, 5, 7},
            new [] {1, 2, 4, 6, 7}
        };
    
        // test
        IEnumerable<int> merged = orderedLists.MergeOrderedLists(i => i);
    
        // expect
        merged.ShouldAllBeEquivalentTo(new [] { 1, 1, 2, 4, 5, 6, 7, 7 });
    }
