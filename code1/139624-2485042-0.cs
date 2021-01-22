    internal interface ILoadValues
    {
        void LoadValues<TKey, TValue>(IDictionary<TKey, TValue> values);
    }
    public class Base : ILoadValues
    {
        void ILoadValues.LoadValues<TKey, TValue>(IDictionary<TKey, TValue> values)
        {
            // Load values.
        }
    }
    public class MyClass<T>
        where T : Base, new()
    {
        public T CreateObject(IDictionary<string,object> values)
        {
            ILoadValues obj = new T();
            obj.LoadValues(values);
            return (T)obj;
        }
    }
