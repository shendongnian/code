    public IQueryable<Info> GetInfo(int count, byte languageId)
    {
        return db.Info.SelectMany(i => i.LanguageInfo)
                          .Where(l => l.Language.id == languageId)
                          .Take(count)
                          .AsEnumerable()
                          .Select(l => new Info {   AddDate = l.Info.AddDate,
                                                    Description = l.Description,
                                                    EntityKey = l.Info.EntityKey,
                                                    id = l.Info.id,
                                                    Title = l.Title,
                                                    ViewCount = l.Info.ViewCount }
                                                    )
                          .OrderByDescending(i => i.id);
    }
