    public async Task<ICollection<Article>> SortArticles(string sortOrder)
    {
        IQueryable<Article> articles = GetAll();
        switch (sortOrder)
        {
            case "name_desc": 
                articles = articles.OrderByDescending(s => s.Name).AsQueryable();			
            break;
            case "date":
                articles = articles.OrderBy(s => s.DateCreated).AsQueryable();
    			break;
            case "date_desc":
                articles = articles.OrderByDescending(s => s.DateCreated).AsQueryable();
    			break;
            default:
                 articles = articles.OrderBy(s => s.Name).AsQueryable();
    			break;
        }
        var result = await articles.ToListAsync();
        return result;
    }
