    public class GenericObject
    {
        private object value;
        public T GetValue<T>()
        {
            return (T)value;
        }
        public void SetValue<T>(T value)
        {
            this.value = value;
        }
        public GenericObject WithValue<T>(T value)
        {
            this.value = value;
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, GenericObject> dict = new Dictionary<string, GenericObject>();
            dict["mystring"] = new GenericObject().WithValue<string>("Hello World");
            dict["myint"] = new GenericObject().WithValue<int>(1);
            int i = dict["myint"].GetValue<int>();
            string s = dict["mystring"].GetValue<string>();
        }
    }
