    public class ArticleDAO :  GenericNHibernateDAO(IArticle, int>, IArticleDAO
    {
        public virtual IArticle GetByTitle(string title)
        {
            // ...
        }
    }
