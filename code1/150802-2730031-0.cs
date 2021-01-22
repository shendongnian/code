    public class SingletonExample
    {
        private static readonly SingletonExample singleInstance
        static SingletonExample()
        {
            singleInstance = new SingletonExample();
        }
        public static SingletonExample Instance
        {
            get { return singleInstance; }
        }
        private SingletonExample()
        {
        }
    }
