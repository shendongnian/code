    public static class SearchableServiceFactory
    {
        static readonly Dictionary<string, Func<ISearchableLookupService<IBaseOutputDto>>> 
            _SearchableLookupServicesRegistry =
                new Dictionary<string, Func<ISearchableLookupService<IBaseOutputDto>>>();
        public static TSearchableLookupService Create<TSearchableLookupService>(string key)
            where TSearchableLookupService : ISearchableLookupService<IBaseOutputDto>
        {
            if (_SearchableLookupServicesRegistry.TryGetValue(
                key,
                out Func<ISearchableLookupService<IBaseOutputDto>> searchableServiceConstructor))
            {
                return (TSearchableLookupService)searchableServiceConstructor();
            }
            throw new ArgumentException($"Service for \"{key}\" not registered.");
        }
        public static void Register(
            string key,
            Func<ISearchableLookupService<IBaseOutputDto>> searchableServiceConstructor)
        {
            _SearchableLookupServicesRegistry.Add(key, searchableServiceConstructor);
        }
    }
