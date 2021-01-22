    public class A
    {
        private EventHandler handlerA;
        
        public virtual void AddEventHandler(EventHandler handler)
        {
            handlerA += handler;
        }
    
        public virtual void RemoveEventHandler(EventHandler handler)
        {
            handlerA -= handler;
        }
    
        // RaiseA stuff
    }
    
    public class B : A
    {
        private EventHandler handlerB;
        
        public override void AddEventHandler(EventHandler handler)
        {
            handlerB += handler;
        }
    
        public override void RemoveEventHandler(EventHandler handler)
        {
            handlerB -= handler;
        }
    
        // RaiseB stuff
    }
