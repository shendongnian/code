    var articleQuery = PhaseContext.PhaseArticles.AsQueryable();
    if(request.ArticleFamily.HasValue)
    {
        articleQuery = articleQuery.Where(a => a.Family == request.ArticleFamily.Value);
    }
    var articleCodes = await articleQuery.ToListAsync(cancellationToken);
