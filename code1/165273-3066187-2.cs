    Context.LogObject = value;
    Context.Log { get; }
    -> Context.LogFactory..ctor
    -> Context.LogFactory.instance = Context.LogObject;
    
    ==> Context.Log == value
