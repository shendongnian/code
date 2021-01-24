    public interface IEntitySearch
    {
        bool IsMatchQuery(Query query);
        Response Search(Query query);
    }
    // without service locator
    public class EntitySearchProvider : IEntitySearchProvider
    {
        private readonly IEnumerable<IEntitySearch> _searchers;
        public EntitySearchProvider(IEnumerable<IEntitySearch> searchers)
        {
            _searchers = searchers;
        }
        public IEntitySearch GetSearcher(Query query)
        {
            // last registered 
            return _searchers.LastOrDefault(i=>i.IsMatchQuery(query))
                ??  throw new NotSupportedException();
        }
    }
