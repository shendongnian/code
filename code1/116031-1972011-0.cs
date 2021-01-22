    public class MyClass
    {
        private MyClass() {}
        public static Create(delegate d ...)
        {
            var instance = new MyClass();
            d.(instance);
            return instance;
        }
    }
