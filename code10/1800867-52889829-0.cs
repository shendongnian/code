    IQueryable<ArticleSummary> Articles = _DbContext.Article
        .Where(a => a.var1 == SomeLocalVariable1)
        .Where(a => a.var2 == SomeLocalVariable2 || a.var2 == SomeLocalVariable3)
        .Where(query);
    foreach(...) {
        Articles = Articles.Where(...);
    }
    Articles = Articles.OrderByDescending(a => a.var6)
        .Select(a => new ArticleSummary
        {
            ArticleCode = a.ArticleCode ,
            var7 = a.var1
            var8 = a.var3
        });
