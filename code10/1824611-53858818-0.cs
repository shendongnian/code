    public class Factory
    {
        private static Func<Base> _getInstance;
        //option if you want to pass in an instantiated value
        public static void SetClass<T>(T newType) where T : Base, new()
        {
            _getInstance = () => new T();
        }
        //option if you just want to give it a type
        public static void SetClass<T>() where T : Base, new()
        {
            _getInstance = () => new T();
        }
        public static Base GetInstance()
        {
            return _getInstance();
        }
        //you could just make GetInstance Generic as well, so you don't have to set the class first
        public static Base GetInstance<T>() where T : Base, new()
        {
            return new T();
        }
    }
