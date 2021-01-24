    Blogs = await _context.Blogs
            .Select(b => new BlogViewModel()
            {
                Id = b.Id,
                Name = b.Name,        
                CategoryName = _context.BlogCategory
                            .Where(c => c.Id == b.CatId)
                            .Select(c => c.Name)
                            .SingleOrDefault()
            })
            .ToListAsync();
