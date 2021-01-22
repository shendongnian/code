    class MyClass<T> where T: struct
    {
        T obj;
        public T Obj
        {
            get { return obj; }
            set { obj = value; }
        }
    }
    MyClass<int> test = new MyClass<int>();
    test.Obj = 1;
