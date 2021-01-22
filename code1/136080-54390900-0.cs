    class MyMarshaledObject : MarshalByRefObject
    {
        public bool DoSomethingRemote() 
        {
          // ... execute some code remotely ...
          return true; 
        }
     
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override object InitializeLifetimeService()
        {
          return null;
        }
    }
