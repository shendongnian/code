    public BaseCollection<T> LoadObject<T>(EventHandler handleEvent)
    {
        var myQuery = BusinessObjectType.Load<T>(MyServiceContext);
        return new DataManager<T>().GetData(myQuery, handleEvent, MyServiceContext);
    }
