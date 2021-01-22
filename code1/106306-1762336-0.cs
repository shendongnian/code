    interface MyInterface
    {
        void Method();
    }
    // Real class
    class MyClass : MyInterface
    {
    }
    // Fake class for recording calls
    class FakeMyClass : MyInterface
    {
        public bool MethodCalled;
        public void Method()
        {
            this.MethodCalled = true;
        }
    }
