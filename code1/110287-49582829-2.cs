    public abstract class BaseClass<T> where T : class
    {
        public static int x = 6;
        public int MyProperty { get { return x; } set { x = value; } }
    }
