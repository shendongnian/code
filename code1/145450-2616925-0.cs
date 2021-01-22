    // arrange
    var loggerStub = MockRepository.GenerateStub<ILogger>();
    // act
    loggerStub.LogMessage("f2");
    // assert
    loggerStub.AssertWasCalled(
        x => x.LogMessage(Arg<string>.Is.Equal("f2"))
    );
