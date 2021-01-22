    [Test]
    public void When_DoSomething_Then_InvokeMyEventHandler()
    {
        var dispatcher = new Mock<IDispatcher>();
    
        ClassUnderTest classUnderTest = new ClassUnderTest(dispatcher.Object);
    
        Action<bool> OnMyEventHanlder = delegate (bool myBoolParameter) { };
        classUnderTest.OnMyEvent += OnMyEventHanlder;
    
        classUnderTest.DoSomething();
    
        //verify that OnMyEventHandler is invoked with 'false' argument passed in
        dispatcher.Verify(p => p.BeginInvoke(OnMyEventHanlder, false), Times.Once);
    }
