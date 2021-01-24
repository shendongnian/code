    public static class SearchableServiceFactory
    {
        static readonly Dictionary<string, Func<object>> _SearchableLookupServicesRegistry =
            new Dictionary<string, Func<object>>();
        public static TSearchableLookupService Create<TSearchableLookupService>(string key)
            where TSearchableLookupService : ISearchableLookupService<IBaseOutputDto>
        {
            if (_SearchableLookupServicesRegistry.TryGetValue(
                key, out Func<object> searchableServiceConstructor)) {
                return (TSearchableLookupService)searchableServiceConstructor();
            }
            throw new ArgumentException($"Service for \"{key}\" not registered.");
        }
        public static void Register(string key, Func<object> searchableServiceConstructor)
        {
            _SearchableLookupServicesRegistry.Add(key, searchableServiceConstructor);
        }
    }
