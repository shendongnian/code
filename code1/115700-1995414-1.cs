    [Test]
    public void load_article_by_title()
    {
        var article1 = new Mock<Article>();
        var mockArticleDao = new Mock<ArticleDAO>(MockBehavior.Strict); //mock set up as strict
        var mockDbFactory = new Mock<IDBFactory>(MockBehavior.Strict); //mock set up as strict
    
        mockDbFactory.Setup(x => x.GetArticleDAO()).Returns(mockArticleDao.Object);
        mockArticleDao.Setup(x => x.GetByTitle(It.IsAny<string>())).Returns(article1.Object);
    
        var articleManager = new ArticleManager(mockDbFactory.Object);
        articleManager.LoadArticle("some title");
    
        Assert.IsNotNull(articleManager.Article);
    }
