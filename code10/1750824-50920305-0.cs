    class A
    {
        public Custom objA = new Custom();
        public A()
        {
            B obj = new B(this);
            B.Func(); // after this, objA field will be null
        }
    }
    class B
    {
        А obj;
        public B(А obj)
        {
            this.obj = obj;
        }
        public void Func()
        {
            obj.objA = null;
        }
    }
