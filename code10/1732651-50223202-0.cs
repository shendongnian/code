    public async Task<bool> IsIdListValid(IEnumerable<int> idList)  
    {
       var validIds = await _context.Foo.Select(x => x.Id).ToListAync();
       return idList.All(x => validIds.Contains(x));
    }
