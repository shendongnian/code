    public class MyOtherClass : MyClass
    {
    }
    
    public class MyOtherGenericClass<T> : IMyInterface<T> where T : MyOtherClass
    {
        T PropertyOfMyClass
        {
            get { ... }
        }
    }
