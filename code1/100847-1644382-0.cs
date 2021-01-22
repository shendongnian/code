    public IList<Entity> Children { get; set; }
    
    public NotifyChildren(Func<Entity, object, bool> action, object data)
    {
       foreach (var child in Children)
       {
           if (action(child, data))
           {
               child.NofifyChildren(action, data); 
           }
       }
    }
    
    public void SomeChangeOccured()
    {
         NotifyChildren((x, data) => x.SomeHandler(data), "somedata");
    }
    public bool SomeHandler(object data)
    {
         return true; // obviously need more robust logic
    }
