    private SomeData GetData() {
        var data = HttpRuntime.Cache.Get("key") as SomeData;
        
        if (data == null) {
            data = DAL.GetData(some parameters...);
            HttpRuntime.Cache.Add("key", data, ....);
        }
        
        return data;
    }
