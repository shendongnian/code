    public List<FeatureModel> FindAll() {
        string key = Cache.GetQueryKey("FindAll");
        var value = Cache.Load<List<FeatureModel>>(key);
        if (value == null) {
            var query = Context.Features;
            value = query.ToList().Select(x => Map(x)).ToList();
            var policy = Cache.GetDefaultCacheItemPolicy(value.Select(x => Cache.GetObjectKey(x.Id.ToString())), true);
            Cache.Store(key, value, policy);
        }
        value = new List<FeatureModel>();
        return value;
    }
