    public class MyGenericClass<T>
    {
        public static MyGenericClass<T> Create()
        {
            return new MyGenericClass<T>();
        }
        public static MyGenericClass<int> CreateDefault()
        {
            return new MyGenericClass<int>();
        }
    }
