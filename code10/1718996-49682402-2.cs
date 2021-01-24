    public class WcfService
    {
        private readonly IEntitySearchProvider _provider;
        public WcfService(IEntitySearchProvider provider)
        {
            _provider = provider;
        }
        public Response SearchEntities(Query query)
        {
            var searcher = _provider.GetSearcher(query);
            return searcher.Search(query);
        }
    }
