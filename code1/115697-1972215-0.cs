    public class ArticleManager : IArticleManager
    {
          private IArticleDAO _articleDAO
    
          public ArticleManger(IArticleDAO articleDAO)
          {
                _articleDAO = articleDAO;
          }
    
          public IArticle LoadArticle(string title)
          {
                return _articleDAO.GetByTitle(title);
          } 
    }
