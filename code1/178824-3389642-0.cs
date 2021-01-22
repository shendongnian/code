    public class MyObject<T>
    {
        public T GetValue(string fieldName, params MyObjectMap<T>[] mappings)
        {
           // Do whatever you need to do
        }
        public MyObjectMap<T> Map(string from, T to)
        {
            return MyObjectMap<T>.Map(from, to);
        }
    }
    public class MyObjectMap<T>
    {
        private MyObjectMap(string from, T to) { }
        public static MyObjectMap<T> Map(string from, T to)
        {
            return new MyObjectMap<T>(from, to);
        }
    }
