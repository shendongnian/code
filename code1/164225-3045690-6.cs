    public class GenericClass<T> where T : class, IFoo, new()
    {
        public T Rar()
        {
            T foo = new T();
            T item = foo.Bar() as T;
            return item;
        }
    }
