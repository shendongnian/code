    class A
    {
       public event FolderStructureChangedHandler EventA;
    
       public void CopyHandlers(B b)
       {
           var handlers = EventA.GetInvocationList();
                foreach (var h in handlers)
                {
                    
                    b.EventB += (EventHandler) h; 
                }
       } 
    }
