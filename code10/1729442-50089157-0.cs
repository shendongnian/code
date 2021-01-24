      public IEnumerable<Article2> GetByString(string word)
    {
        IEnumerable<Article2> article2 = _appContext.Article2
            .Include(t => t.ParentPage)
            .Where(t => t.Status == RecordStatus.Enabled && (t.Name.Contains(word) || t.Description.Contains(word))).ToList();
        return article2;
    } 
