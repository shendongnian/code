    public interface IViewDataFactory
    {
        T Create<T>(IEnumerable<Page> pages) where T : MasterViewData, new();
    }
    public class ViewDataFactory : IViewDataFactory
    {        
        public T Create<T>(IEnumerable<Page> pages) where T : MasterViewData, new()
        {
            T t = new T();
            t.Pages = pages;
            return t;
        }
    }
