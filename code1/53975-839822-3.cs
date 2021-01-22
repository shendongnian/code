    public class Foo
    {
        private readonly OneShot<int> setOnce;        
        
        public OneShot<int> SetOnce
        {
            get { return setOnce; }
        }
        
        public Foo() :
            this(null)
        {
        }
        
        public Foo(OneShot<int> setOnce)
        {
            this.setOnce = setOnce;
        }
    }
