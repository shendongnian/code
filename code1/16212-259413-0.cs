    public interface MyInterface { void MyMethod(); }
    public class MyClass: MyInterface
    {
        public static void MyMethod() { //Do Something; }
    }
    
     // inside of some other class ...  How would you call the method on the interface ???
        MyClass.MyMethod();  // this calls the method normally not through the interface...
    
        // This next fails you can't cast a classname to a different type... 
        // Only instances can be Cast to a different type...
        MyInterface myItf = MyClass as MyInterface;  
