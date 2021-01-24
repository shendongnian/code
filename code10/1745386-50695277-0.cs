    public void GetArticlesByState(ArticleStateEnum nse)
    {
        string stateText = nse.ToString();
        var articleList = db.Articles.Where(x => x.ArticleState == stateText);
        ...
    }
