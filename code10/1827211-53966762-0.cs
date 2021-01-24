    public class GetCoinByIdQuery : IRequest<CoinModel>, IProvideCacheKey
    {
        public int Id { get; set; }
        public string CacheKey => $"{GetType().Name}:{Id}";
    }
