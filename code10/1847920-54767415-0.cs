    public class MyBaseClass { }
    public class MyClass : MyBaseClass { }
    public class MyClass2 : MyBaseClass
    {
        public MyClass2(int x)
        {
        }
    }
    public class SomeOtherClass { }
    public static void MyMethod<T>() where T : MyBaseClass, new() { }
    public static void Main(string[] args)
    {
        MyMethod<MyBaseClass>(); // Works because T is the correct class
        MyMethod<MyClass>(); // works because T is MyClass, which is derived from MyBaseClass
        MyMethod<MyClass2>(); // Doesn't work because it doesn't have a Std.Constructor "MyClass2()" it has a constructor with parameters "MyClass2(int x)"
        MyMethod<SomeOtherClass>(); // Doesn't work because T is SomeOtherClass, and it's not derived from MyBaseClass.
    }
