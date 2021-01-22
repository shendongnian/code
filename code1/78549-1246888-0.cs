    public class MyBase<T>
    {
        public T Clone()
        {
            return default(T);
        }
    }
    public class MyDerived : MyBase<MyDerived>
    {
    }
