    public BaseCollection<T> LoadObject<T>(EventHandler handleEvent)
    {
        var myQuery = BusinessUtil.Load<T>(MyServiceContext);
        return new DataManager<T>().GetData(myQuery, handleEvent, MyServiceContext);
    }
