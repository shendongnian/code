    //Arrange
    SomeObj mock = MockRepository.GenerateMock<SomeObj>();
    mock.Expect(m => m.GetNumOfThings()).Return(1);
    mock.Expect(m => m.SomeProp).Return(SomeEnum.YO).Repeat.Once();
    SomeClass sc = new SomeClass();
    sc.SetSomeObj(mock);
    //Act
    sc.Initialise();
    
    //Assert
    mock.VerifyAllExpectations();
