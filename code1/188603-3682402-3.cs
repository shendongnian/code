        public interface IOutputCacheVaryByCustom
        {
            string CacheKey { get; }
            IOutputCacheVaryByCustom NewObject();
        }
