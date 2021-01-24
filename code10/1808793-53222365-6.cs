    public abstract BaseEvent : IEvent
    {
         protected BaseEvent(string name);
         //Method must be implemented
         public abstract SomeMethod();
         
         //Method can be overriden
         public virtual DoSomething()
         {
         }
    }
