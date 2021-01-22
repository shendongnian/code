    public class MyClass
    {
        public object this[string key]
        {
            get { return SubItems[key]; }
            set { SubItems[key] = value; }
        }
    }
