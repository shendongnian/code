    private delegate void NodeHandler(ChildNode node);
    
    static Dictionary<RuntimeTypeHandle, NodeHandler> TypeHandleSwitcher = CreateSwitcher();
    
    private static Dictionary<RuntimeTypeHandle, NodeHandler> CreateSwitcher()
    {
        var ret = new Dictionary<RuntimeTypeHandle, NodeHandler>();
    
        ret[typeof(Bob).TypeHandle] = HandleBob;
        ret[typeof(Jill).TypeHandle] = HandleJill;
        ret[typeof(Marko).TypeHandle] = HandleMarko;
    
        return ret;
    }
    
    void HandleChildNode(ChildNode node)
    {
        NodeHandler handler;
        if (TaskHandleSwitcher.TryGetValue(Type.GetRuntimeType(node), out handler))
        {
            handler(node);
        }
        else
        {
            //Unexpected type...
        }
    }
