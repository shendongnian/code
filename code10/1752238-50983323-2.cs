    public async Task<IEnumerable<Product>> GetSpecificProducts 
         (List<int> brands, List<int> categories, bool? sugar)
    {
        IQueryable<Product> query = _context.Products;
        
        if(brands.Any()) 
            query = query.Where(x => brands.Contains(x.BrandId));
        
        if(categories.Any()) 
            query = query.Where(x => categories.Contains(x.CategoryId));
        
        if(sugar.HasValue) 
            query = query.Where(x => x.Sugar == sugar);
        
        var products = await query.ToListAsync();
    }
