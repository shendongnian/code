    public void GetArticlesByState(ArticleStateEnum nse)
    {
        var articleList = db.Articles
             .Where(x => x.ArticleState == Enum.GetName(typeof(ArticleStateEnum), nse));
    }
