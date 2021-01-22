    public BaseCollection<T> LoadObjectType1e<T>(EventHandler handleEvent, Func<QueryType> querySelector) 
    { 
        var myQuery = querySelector(MyServiceContext); 
        return new DataManager<T>().GetData(myQuery , handleEvent, MyServiceContextt); 
    } 
     
    public BaseCollection<T> LoadDepositionSampleTypeItemSource<T>(EventHandler handleEvent, Func<QueryType> querySelector) 
    { 
       var myQuery = querySelector(MyServiceContext); 
       return new DataManager<T>().GetData(myQuery , handleEvent, MyServiceContextt); 
    } 
     
    public BaseCollection<T> LoadLabResultItemSource<T>(EventHandler handleEvent, Func<QueryType> querySelector) 
    { 
       var query = querySelector(MyServiceContext); 
       return new DataManager<T>().GetData(query, handleEvent, MyServiceContextt); 
    } 
