    public IQueryable<TEntity> Get<TEntity>(int page, int size) where TEntity : Entity
    {
        return _context
            .Query<TEntity>()
            .GroupBy(d => d.Id)
            .Select(g => g.OrderByDescending(d => d.Version))
            .Select(e => e.First())
            .Where(x => !x.IsDeleted)
            .Skip(page * size)
            .Take(size);
    }
