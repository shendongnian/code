    class MyUnitTestableClass
    {
        public MyUnitTestableClass(IMockable foo)
        {
            // do stuff
        }
        public MyUnitTestableClass()
            : this(new DefaultImplementation())
        {
        }
    }
