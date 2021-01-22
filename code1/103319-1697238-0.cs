    public interface ISearchable {
        void doFindElements<T>(List<T> putThemHere);
    }
    // this is extender for syntactical sugar
    public static class SearchableExtender
    {
        public static IEnumerable<T> findElements<T>(this ISearchable obj)
        {
            List<T> result = new List<T>();
            obj.doFindElements(result);
            return result;
        }
    }
    public abstract class Container : ISearchable {
    ...
        public virtual void doFindElements<T>(List<T> putThemHere)
        {
            if (this is T) putThemHere.Add(this);
            foreach (Container item in _children) { item.doFindElements(putThemHere); }
        }
    ...
    }
    
