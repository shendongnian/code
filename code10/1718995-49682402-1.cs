    public interface IEntitySearchProvider
    {
        IEntitySearch GetSearcher(Query query);
    }
    public class EntitySearchProvider : IEntitySearchProvider
    {
        private readonly IComponentContext _container;
        public EntitySearchProvider(IComponentContext container)
        {
            _container = container;
        }
        public IEntitySearch GetSearcher(Query query)
        {
            switch(query.Entity)
            {
                case "Assets":
                    return _container.Resolve<AssetSearch>();
                case "Stages":
                    return _container.Resolve<StageSearch>();
                default:
                    throw new NotSupportedException();
            }
        }
    }
