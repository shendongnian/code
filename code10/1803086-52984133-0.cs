    public class CacheHelper : ICacheHelper
    {
        private readonly IUnitOfWork unitOfWork;
        public IMemoryCache Cache { get; }
        public CacheHelper(IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            this.unitOfWork = unitOfWork;
            Cache = cache;
        }
        public string GetCities()
        {
            if(!Cache.TryGetValue<string>("cities", string out cities))
            {
                // not found in cache, obtain it
                cities = unitOfWork.CityRepo.GetAll();
                Cache.Set("cities", cities);
            }
            return cities;
        }
    }
