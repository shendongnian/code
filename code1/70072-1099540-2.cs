    public static class MyGenericClassFactory
    {
        public static MyGenericClass<T> Create<T>()
        {
            return new MyGenericClass<T>();
        }
        public static MyGenericClass<int> Create()
        {
            return new MyGenericClass<int>();
        }
    }
    var foo = MyGenericClassFactory.Create(); // now we have an int definition
    var bar = MyGenericClassFactory.Create<MyEnum>();
