    [Test]
    public void MyMethod_ShouldSetSomeClassPropToTrue()
    {
        MockRepository mocks = new MockRepository();
        ISomeClass someClass = mocks.StrictMock<ISomeClass>();
        MyClass classUnderTest = new MyClass(someClass);
        someClass.SomeProp = true;
        LastCall.IgnoreArguments();
            // Expect the property be set with true.
        mocks.ReplayAll();
        classUndertest.MyMethod();
            // Run the method under test.
        mocks.VerifyAll();
    }
