        class MyBase
    {
        readonly int _x;
        public MyBase(int x)
        {
            _x = x;
        }
        protected MyBase()
        {
            _x = 0;
        }
    }
    class MyChild : MyBase
    {
        public MyChild()
        {
        }
    }
