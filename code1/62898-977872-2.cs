    public class MyType
    {
        private MyType() // prevent direct creation through default constructor
        {  
        }
        public static MyType CreateNewMyType()
        {
            return new MyType();
        }
    }
