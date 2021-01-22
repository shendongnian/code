    public class Thing
    {
        Dictionary<Type, object> xDict = new Dictionary<Type,object>();
        public void set_X<T>(T x)
        {
            xDict[typeof(T)] = x;
        }
        public T get_X<T>()
        {
            return (T)xDict[typeof(T)];
        }
    }
