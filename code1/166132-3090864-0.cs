    public class Foo
    {
        private int _myOwn = 1;
        protected int _mineAndChildren = 2;
        public int _everyOnes = 3;
    }
    
    public class Bar : Foo
    {
        public void Method()
        {
            _myOwn = 2; // Illegal - can't access private member
            _mineAndChildren = 3; // Works
            _everyOnes = 4; // Works
        }
    }
    
    public class Unrelated
    {
        public void Method()
        {
            _myOwn = 2; // Illegal - can't access private member
            _mineAndChildren = 3; // Illegal
            _everyOnes = 4; // Works
        }
    }
