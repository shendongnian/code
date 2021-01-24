    //Arrange
    SomeObj mock = MockRepository.GenerateMock<SomeObj>();
    mock.Expect(_ => _.GetNumOfThings()).Return(1);
    mock.Expect(_ => _.SetSomething(Arg<int>.Any())).Throw(new Exception());
    mock.Expect(_ => _.SomeProp).Return(SomeEnum.YO).Repeat.Once();
    SomeClass sc = new SomeClass();
    sc.SetSomeResource(mock);
    //Act
    sc.MethodToTest();
    
    //Assert
    mock.VerifyAllExpectations();
