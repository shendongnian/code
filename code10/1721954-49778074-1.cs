    var preliminary = database.News
        .Where(news => tagsList.Any(t => news.Tags.Contains(t)))
        .ToList();
    var tagSet = new HashSet<string>(tagList);
    return preliminary.Select(news => new {
        News = news
    ,   MatchCount = news.Tags.Split(';').Count(t => tagSet.Contains(t))
    }).Where(p => p.MatchCount > 0)
    .OrderByDescending(p => MatchCount)
    .Select(p => p.News);
