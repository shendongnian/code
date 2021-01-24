    IEnumerable<PopularArticle> Get(Dictionary<Guid, SOMETHING> variable)
    {
        return articleService.GetArticlesFromGuidList(variable.Select(x => x.Key), wcagOnly: branding.StrictlyWCAG2Accessible, useCache: true)
            .Select(x => new PopularArticle() { Article = x, ArticleGuid = x.ArticleGUID })
            .Where(x => contentAdminTestingDataFilterService.AllowFirmAccess(x.Article.FirmRef, lexUser) && x.Article.RemoveDate != null)
            .OrderByDescending(x => variable[x.ArticleGuid])
            .Take(Records);
    }
