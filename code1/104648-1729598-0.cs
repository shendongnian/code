    public abstract class MyClass
    {
        public static MyClass New()
        { return new InternalMyClass(); }
    }
    class InternalMyClass : MyClass
    { }
  
