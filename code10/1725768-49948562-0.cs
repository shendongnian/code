    var pages = _dbContext.Page.Select(page => new Page
        {
            Id = page.Id,
            Title = page.Title
        }).ToList();
    
    pages.ForEach(p => _dbContext.Page.Attach(p));
