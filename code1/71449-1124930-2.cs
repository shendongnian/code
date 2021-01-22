    MockRepository mocks = new MockRepository();
    IDal dalMock = mocks.CreateDynamicMock<IDal>();
    // expect the correct argument
    Expect.Call(dalMock.GetDataSet(Arg<int>.Is.Equal(7)))
      .Return(emptyDataSet)
      .Repeat.Once();
    // setup mock to return the emptyDataSet for any argument    
    SetupResult.For(dalMock.GetDataSet(Arg<int>.Is.Anything))
      .Return(emptyDataSet)
      .Repeat.Any();
    sut.Execute()
    
    // assert that the argument had been 7
    mocks.VerifyAll();
