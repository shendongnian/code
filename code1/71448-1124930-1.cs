    IDal dalMock = MockRepository.GenerateMock<IDal>();
    // setup mock to return the emptyDataSet for any argument    
    dalMock
      .Stub(x => x.GetDataSet(Arg<int>.Is.Anything))
      .Return(emptyDataSet)
      .Repeat.Any();
    sut.Execute()
    
    // assert that the argument had been 7
    dalMock.AssertWasCalled(x => x.GetDataSet(Arg<int>.Is.Equal(7))
