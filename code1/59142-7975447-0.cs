    public class MyClass
    {
        private readonly int _a;
        private readonly int _b;
        private readonly string _x;
    
        public MyClass(int a, int b, string x)
            : this(x)
        {
            _a = a;
            _b = b;
        }
    
        public MyClass()
            : this("(not set)")
        {
            // Nothing set here...
        }
    
        private MyClass(string x)
        {
            _x = x;
        }
    }
