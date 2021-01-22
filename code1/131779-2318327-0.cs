    public IQueryable<ITag> fGetNewsTags(int id)
    {
        var result = from news in context.GetTable<NewsTag>()
                     where news.M_Id == id
                     select (ITag)news;
    
        return result;
    }
