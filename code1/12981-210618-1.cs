    public class BaseClass
    {
        public virtual void DoStuff() { }
    }
    
    public class ClassA : BaseClass
    {
        public object PropertyA { get; set; }
        public override void DoStuff() 
        {
            // do stuff with PropertyA 
        }
    }
    
    public class ClassB : BaseClass
    {
        public object PropertyB { get; set; }
        public override void DoStuff() 
        {
            // do stuff with PropertyB
        }
    }
