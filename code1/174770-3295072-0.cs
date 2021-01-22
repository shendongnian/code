    var entries = new[] { new Entry{ ID = 1,  Title = "Baking a chicken, bacon and leek pie"} }.AsQueryable();
    var search = "chicken bacon turnip";
    var q = entries.Select(GetSelector(search));
    var matches = q.Where(e => e.MatchCount > 1);
    public Expression<Func<Entry, EntryMatchCount>> GetSelector(string search)
    {
        var searchWords = search.Split(new[] {' '});
        // Rather than creating the selector explicitly as below, you'll want to
        // write code to generate this expression tree.
        Expression<Func<Entry, EntryMatchCount>> selector = e =>
                new EntryMatchCount
                {
                    ID = e.ID,
                    MatchCount = (e.Title.Contains(searchWords[0]) ? 1 : 0) +
                                (e.Title.Contains(searchWords[1]) ? 1 : 0) +
                                (e.Title.Contains(searchWords[2]) ? 1 : 0)
                };
        return selector;
    }
