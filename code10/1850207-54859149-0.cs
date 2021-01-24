    public async Task<Parent> GetParent(int id)
    {
        var parent = context.Parents
            .Include(p => p.Children)
            .SingleOrDefaultAsync(p => p.Id == id);
        parent.Result.Children = parent.Result.Children.OrderBy(c => c.Sequence).ToList();
        return await parent;
    }
