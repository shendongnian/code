    public interface MyInterface
    {
       object MyProperty { get; }
    } 
    
    public interface MyInterfaceProtected
    {
       object MyProperty { set; }
    }
    
    public class MyClass : MyInterFace, MyInterfaceProtected
    {
       private object _myProperty;
       public object MyProperty { get {return _myProperty;} }
       object MyInterfaceProtected.MyProperty
       {
          set { _myProperty = value; }
       }
    }
