    public abstract class BaseClass : VeryBaseClass
    {
        public BaseClass(string className, MyObject myObject) :
            base(className, myObject)
        {
            
        }
    }
    
    public class InheritedClass : BaseClass
    {
        public InheritedClass(MyObject myObject) : base("InheritedClass", myObject)
        {
    
        }
    }
