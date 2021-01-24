    if(!request.ArticleFamily.HasValue)
    // or throw an exception here
     return ...;
    ArticleFamily newVariable = (ArticleFamily)Enum.Parse(typeof(ArticleFamily), request.ArticleFamily);
    var articleCodes = await PhaseContext.PhaseArticles
        .Where(a => a.Family == newVariable)
        .ToListAsync(cancellationToken);
