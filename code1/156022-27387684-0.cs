    // Common interface of my singleton classes
    public interface IMySingletonClass
    {
        string ValueGetter();
        void ValueSetter(string value);
    }
    // Generic abstract base class
    public abstract class Singleton<T>: IMySingletonClass
    {
        private static readonly object instanceLock = new object();
        private static T instance; // Derived class instance
        // Protected constructor accessible from derived class
        protected Singleton()
        {
        }
        // Returns the singleton instance of the derived class
        public static T GetInstance()
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = (T)Activator.CreateInstance(typeof(T), true);
                }
                return instance;
            }
        }
        // IMySingletonClass interface methods
        public abstract string ValueGetter();
        public abstract void ValueSetter(string value);
    }
    // Actual singleton class
    public class MySingletonClass : Singleton<MySingletonClass>
    {
        private string myString;
        private MySingletonClass()
        {
            myString = "Initial";
        }
        public override string ValueGetter()
        {
            return myString;
        }
        public override void ValueSetter(string value)
        {
            myString = value;
        }
    }
