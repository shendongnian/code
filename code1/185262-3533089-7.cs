    public BaseCollection<T> LoadObject<T>(EventHandler handleEvent,
        Func<ServiceContext, T> generator)
    {
        var myQuery = generator(MyServiceContext);
        return new DataManager<T>().GetData(myQuery, handleEvent, MyServiceContext);
    }
    // ...
    var obj = LoadObject(handleEvent, Object1.Load);
