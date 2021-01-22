    interface IBaseInterface
    {
        event EventHandler SomeEvent;
    }
    
    interface IInterface1 : IBaseInterface
    {
        event EventHandler SomeEvent;
    }
    
    interface IInterface2 : IBaseInterface
    {
        event EventHandler SomeEvent;
    }
    
    class Foo : IInterface1, IInterface2
    {
    
        public event EventHandler SomeEvent
        {
            add { }
            remove { }
        }
    
        event EventHandler IInterface1.SomeEvent
        {
            add { }
            remove { }
        }
    
    
        event EventHandler IInterface2.SomeEvent
        {
            add { }
            remove { }
        }
    }  
