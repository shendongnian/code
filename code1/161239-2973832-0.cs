    // arrange
    var serviceStub = MockRepository.GenerateStub<IService>();
    serviceStub.Stub(x => x.AsyncOperationWithCallBack(Arg<Action>.Is.NotNull))
        .WhenCalled(
            invokation =>
            {
                var callback = (Action)invokation.Arguments[0];
                callback();
            });
    
    var dataProvider = new DataProvider(serviceStub);  
    
    // act
    bool raised = false;
    dataProvider.MyEvent += delegate { raised = true; };
    dataProvider.DoSomething();
    
    // assert
    serviceStub.AssertWasCalled(
        x=>x.AsyncOperationWithCallBack(Arg<Action>.Is.NotNull));
    Assert.IsTrue(raised);
