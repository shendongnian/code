    public virtual class WrapperClass : IClosedClassInterface1, IClosedClassInterface2
    {
        protected ClosedClass object;
        public ClosedClass()
        {
            object = new ClosedClass();
        }
        public void Method1()
        {
            object.Method1();
        }
        public void Method2()
        {
            object.Method2();
        }
    }
