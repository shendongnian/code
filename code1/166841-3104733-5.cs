    public class MyClass
    {
        protected MyClass() { /* Do Something */ }
        public static MyClass Create(string someParam)
        {
            /* Do something with someParam */
            return new MyClass();
        }
    }
