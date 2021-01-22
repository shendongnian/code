    private SomeData GetDataAndCache() {
        var data = DAL.GetData(some parameters...);
        HttpRuntime.Cache.Add("key", data, ....);
        return data;
    }
    
    private SomeData GetData() {
        var data = HttpRuntime.Cache.Get("key") as SomeData;
        return data ?? GetDataAndCache();
    }
