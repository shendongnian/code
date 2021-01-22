    Class A
    {
        B classB;
    
        public A()
        {
            classB = new B();
        }
    
        public void Act()
        {
            B.Do(this);
        }
    }
