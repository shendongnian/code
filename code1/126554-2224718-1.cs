    public interface IRenderer<T> where T: NewsItem 
    {
       string Render(T item);
    }
    public class NewsItemJoinerRenderer: IRenderer<NewsItemJoiner>
    {
       public string Render(T item)
       {
           return "XXX has just joined our music network";
       }
    }
    
    public class NewsRendererFactory
    {
       public IRenderer<T> GetRenderer<T>()
       {
            return ServiceLocator.GetInstance<IRenderer<T>>();
       }
    }
