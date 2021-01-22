    public class Class1 
    {
        public Class1()
        {
            SomeControl control = new SomeControl();
            Class2 class2 = new Class2();
            control.SomeEvent += class2.EventHandler;
        }
    }
    
    public class Class2
    {
        public void EventHandler() {}
    }
