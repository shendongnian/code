    public static Expression<Func<Post, bool>> WhereActive
    {
        get
        {
            return p => p.Public && p.PublishedDate > DateTime.Now;
        }
    }
