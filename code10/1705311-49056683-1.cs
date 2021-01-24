    Table1 table = ...
    
    // this creates a proxy (dynamic type) which derives from Table1. This can be used to wrap ANY type with a status property
    Table1 proxy = ProxyGenerator.WrapConcreteWithStatusProxy(table);
    // the IStatusObject interface and implementation is being provided by the proxy, and is only accessible via a cast.
    IStatusObject tableStatus = (IStatusObject)proxy;
    tableStatus.Status = Statuses.Good;
