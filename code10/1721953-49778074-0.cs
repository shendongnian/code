    var preliminary = database.News
        .Where(news => tagsList.Any(t => news.Tags.Contains(t)))
        .ToList();
    var tagSet = new HashSet<string>(tagList);
    return preliminary.Where(news => news.Tags.Split(';').Any(t => tagSet.Contains(t)));    
