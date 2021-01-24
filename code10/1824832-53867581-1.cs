    public class ArticleViewModel : IComponentAreaViewModel<Article>
    {
        // use this property, when you need ArticleModel
        public ArticleModel Model { get; }
        IComponentAreaModel<Article> IComponentAreaViewModel<Article>.Model => Model;
    }
