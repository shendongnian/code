    public class Class1 
    {
        public Class1()
        {
            new Class2().CreateControl(EventHandler);
        }
    
        public void EventHandler() {}
    }
    
    public class Class2
    {
        public void CreateControl(Action eventHandler)
        {
            SomeControl control = new SomeControl();
            control.SomeEvent += eventHandler;
        }
    }
