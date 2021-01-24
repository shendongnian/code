    public int Add(TEntity item)
    {
        _context.Set<TEntity>().Add(item);
        _context.SaveChanges();
        return item.Id;
    }
