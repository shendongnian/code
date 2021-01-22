    public List<Product> GetProducts(int start, int offset)
    {
        IEnumerable<Product> query = from m in db.Products
                                     orderby m.Id descending
                                     select m;
        query = query.Skip(start).Take(offset);
        return query.ToList();
    }
