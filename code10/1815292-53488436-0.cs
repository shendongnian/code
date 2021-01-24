    Class A
    {
        B classB;
        public A()
        {
            classB = new B(this);
        }
        public void funcIHaveToUseInClassB()
        {
        }
    }
    Class B
    {
        A classA;
        public B(A arg)
        {
             classA = arg;
        }
        public void funcIHaveToUseInClassA()
        {
        }
    }
