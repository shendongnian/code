    class MyClass<T> 
    {
        static T _storage;
 
        public void DoSomethingWith(T obj)
        {
            _storage = obj;
        }
    }
    interface IMyInterface { }
    class Derived : IMyInterface { }
    MyClass<Derived> a = new MyClass<Derived>();
