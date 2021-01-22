    public class DynamicValue<T>
    {
        internal DynamicValue(T value, bool exists)
        {
             Value = value;
             Exists = exists;
        }
    
        T Value { get; private set; }
        bool Exists { get; private set; }
    }
