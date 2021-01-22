    public class BaseClass {
        protected string X;
        public BaseClass() {
            this.X = "Foo";
        }
    }
    public class MyClass : BaseClass
    {
        public MyClass() 
            // no ref to base needed
        {
            // initialise stuff
            this.X = "bar";
        }
    
        public MyClass(int param1, string param2)
            :this() // This is needed to hit the parameterless ..ctor
        {
             // this.X will be "bar"
        }
        public MyClass(string param1, int param2)
            // :base() // can be implied
        {
             // this.X will be "foo"
        }
    }
