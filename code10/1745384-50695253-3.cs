    public void GetArticlesByState(ArticleStateEnum nse)
    {
        string state = Enum.GetName(typeof(ArticleStateEnum), nse);
        var articleList = db.Articles.Where(x => x.ArticleState == state);
    }
