    Context.LogFactory..ctor
    Context.LogFactory.instance = Context.LogObject ?? new BaseLogger(...);
    ...
    Context.LogObject = value;
    Context.Log { get; }
    ==> Context.Log != value
