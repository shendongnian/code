    var CategoriesUnderParent = AppContext.Articles
    .Where(c => c.ArticleCategoryParent == {parent});
    foreach(var category in CategoriesUnderParent)
    {
        var ArticlesAllowed = category.ArticleCategoryRelations
             .Where(acr => acr.Article.Approved == 1).Select(a => a.Article);
        
        var ArticlesPicked = ArticlesAllowed
             .OrderByDescending(ar => ar.ArticleDate)
             .Take(2);
       // Do something with your data
    }
