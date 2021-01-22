    public BaseCollection<T> LoadGeneric<T>(EventHandler handleEvent)
    {
        var myQuery = (YourQueryType)typeof(T)
            .GetMethod("Load")
            .Invoke(null, new object[] { MyServiceContext });
        return new DataManager<T>().GetData(myQuery , handleEvent, MyServiceContextt);
    }
