    public class BaseClass
    {
        public BaseClass() { }
    
        public object p1 { get; set;}
    
        public object p2 { get; set; }
    
        public virtual void ImplementLogic()  
        {
            //do some fun stuff....
        }
    }
    
    public class ClassA : BaseClass
    {
        public ClassA { }
    
        public override void ImplementLogic()
        {
            //make it rain.....
        }
    } 
    
    public class ClassB : BaseClass
    {
        public ClassB { }    
    
        public override void ImplementLogic()
        {
            //do some more fun stuff
        }
    }
