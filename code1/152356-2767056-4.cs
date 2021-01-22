    public class MyClass
    {
        public static int MyInt;
        public static MyOtherClass MyOther;
    }
    
    // elsewhere in code, before you instantiate MyClass:
    MyClass.MyInt = 12;
    MyClass.MyOther = new MyOtherClass();
    MyClass myClass = new MyClass();
