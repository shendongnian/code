    public interface InterfaceOne
    {
        int myBackingVariable;
    
        int MyProperty { get { return myBackingVariable; } }
    }
    
    public interface InterfaceTwo
    {
        int myBackingVariable;
    
        int MyProperty { get { return myBackingVariable; } }
    }
    
    public class MyClass : InterfaceOne, InterfaceTwo { }
