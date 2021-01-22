    class ConditionalCallback()
    {
         public Predicte<Item>   Predicate {get; set;}
         public Action<Item>     Callback  {get; set;}
    }
    
    List<ConditionalCallback> callbacks = new List<ConditionalCallback>();
    
    public AddCallBack(Predicte<Item> pred, Action<Item> callback)
    {
        callbacks.Add(new ConditionalCallback { 
                                  Predicate = pred, 
                                  Callback = callback
                                   });
    }
    
    
    void HandleItem(Item item)
    {
         foreach(var cc in callbacks)
             if (cc.Predicate(item))    
                 cc.Callback(item);
    }
    // 
    AddCallBack( i=> i.ID1 = 2 && i.ID2 = 160 && i.ID3 = anything", MyCallback);
