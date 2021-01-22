    public class MyClass()
    {
        public MyClass() {}
        protected MyClass(MyClass other)
        {
            // Cloning code goes here...
        }
        public MyClass Clone()
        {
            return new MyClass(this);
        }
    }
