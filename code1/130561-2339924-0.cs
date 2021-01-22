    public abstract class VeryBaseClass
    {
        public VeryBaseClass(string className, MyObject myObject)
        {
            this.ClassName = className;
        }
    
        public string ClassName{ get; set; }
    }
    public abstract class BaseClass<T> : VeryBaseClass
    {
        public BaseClass(MyObject myObject)
            : base(typeof(T).Name, myObject)
        {
        }
    }
    
    public class InheritedClass : BaseClass<InheritedClass>
    {
        public InheritedClass(MyObject myObject) 
            : base(myObject)
        {
            
        }
    }
