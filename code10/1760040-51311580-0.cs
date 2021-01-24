    // let's assume this is in your service class
    // you most likely want a better name
    public Task<List<Tuple<int, string>>> GetItemsAsEnumAsync()
    {
        return _context.SomeTable
            .Select(x => Tuple.Create(x.Id, x.Name))
            .ToListAsync();
    }
