    public interface IManager
    {
        void Foo(IEvent nonSpecificEvent);
        //... 
    }
    public interface IManager<TEvent> : IManager
        where TEvent : IEvent
    {
        void Foo(TEvent mySpecificEvent);
        //... 
    }
