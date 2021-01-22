    public class MyClass {
        public delegate string MyDelegate();
        public string MyMethod1() {
            return "Hello";
        }
        public string MyMethod2() {
            return "Bye";
        }
    }
    MyClass myInstance;
    MethodInfo method = typeof(MyClass).GetType().GetMethod("MyMethod1");
    MyClass.MyDelegate del = Delegate.CreateDelegate(typeof(MyClass.MyDelegate), myInstance, method);
