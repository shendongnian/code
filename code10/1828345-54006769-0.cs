    TestType obj = Activator.CreateInstance(typeof(TestType), 1, 2) as TestType;
    class TestType
    {
        public TestType(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int a;
        public int b;
    }
