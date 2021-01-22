    public class Class1 
    {
        public Class1()
        {
            Class2 class2 = new Class2();
            class2.Control.SomeEvent += this.EventHandler;
        }
    
        public EventHandler()
        {
            //DoStuff
        }
    }
    
    public class Class2
    {
        public Control control;
    }
