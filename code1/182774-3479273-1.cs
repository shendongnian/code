    List<int> myTags = GetTagIds();
    int tagCount = myTags.Count;
    
    IQueryable<int> subquery =
      from tag in myDC.Tags
      where myTags.Contains(tag.TagId)
      group tag.TagId by tag.ContentId into g
      where g.Distinct().Count() == tagCount
      select g.Key;
    
    IQueryable<Content> query = myDC.Contents
      .Where(c => subQuery.Contains(c.ContentId));
