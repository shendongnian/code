    public interface IComponentAreaViewModel<T, TModel>
        where TModel : IComponentAreaModel<T>
    {
        TModel Model { get; }
    }
    public class ArticleViewModel : IComponentAreaViewModel<Article, ArticleModel>
    {
        public ArticleModel Model { get; }
    }
