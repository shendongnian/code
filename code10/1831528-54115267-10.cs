    public abstract class ValueAsset<T> : ScriptableObject
    {
        public T value;
    
        // Add your methods
        // Here some more examples also using the T value. They might also be abstract but they don't have to be
        // return a T
        public T GetValue()
        {
            return value;
        }
        // or pass a T
        public void SetValue(T input)
        {
            value = input;
        }
    }
