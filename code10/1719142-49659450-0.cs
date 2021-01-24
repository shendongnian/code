    class Inner
    {
        protected readonly int _i;
   
        public Inner(int i)
        {
            _i = i;
        }
    }
    class Outer
    {
        protected Inner _inner = null;
        public Outer()
        {
            //Construct
        }
        public void SetI(int i)
        {
            _inner = new Inner(i);
        }
    }
