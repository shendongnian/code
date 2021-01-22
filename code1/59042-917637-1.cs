    public class MyClass<T>
    {
        public static implicit operator MyClass<T>(Func<T, T> func)
        {
            return new MyClass<T>() { MyFunction = func };
        }
        public MyClass()
        {
        }
        public Func<T, T> MyFunction
        {
            get;
            set;
        }
    }
