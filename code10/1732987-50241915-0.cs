    public IList<Content> GetContent(bool? IsPublished) {
        var ans = _UoW.Content.All;
        if (IsPublished.HasValue)
            ans = ans.Where(c => c.IsPublished == IsPublished);
        return ans.ToList();
    }
