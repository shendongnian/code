    public interface IFoo
    {
        IList<News> GetNews();
    }
    
    public class InProcFoo : IFoo
    {
    
       private static IList<News> news;
    
       public InProcFoo()
       {
           news = new List<News>();
           news.Add(new News());
       }
    
       public IList<News> GetNews()
       {
          return news;
       }
    }
