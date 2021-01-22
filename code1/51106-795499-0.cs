    class A
    {
        B b;
        public B B
        {
            set
            {
                b = value;
                b.a = this;
            }
            get
            {
                return b;
            }
        }
    }
    class B
    {
        public A a;
    }
