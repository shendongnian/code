    public List<Author> Get()
    {
        db.Configuration.LazyLoadingEnabled = false;
        return db.Authors.Include(a => a.Books).AsNoTracking().ToList();
    }
