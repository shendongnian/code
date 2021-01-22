    public Amazing_Mocking_Test()
    {
        //Mock object setup
        MockObject mockery = new MockObject();
        IHelper myMock = (IHelper)mockery.createMockObject<IHelper>();
        mockery.On(myMock).Expect("GetSomeData").WithNoArguments().Return(Anything);
        //The actual test
        MyClass testClass = new MyClass(myMock);
        testClass.LoadData();
        //Ensure the mock had all of it's expectations met.
        mockery.VerifyExpectations();
    }
