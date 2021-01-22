    // arrange
    var loggerStub = MockRepository.GenerateStub<ILogger>();
    // act
    loggerStub.LogMessage("f2");
    // assert
    loggerStub.AssertWasCalled(
        x => x.LogMessage(Arg<string>.Matches(
            s => string.Equals(s, "f2", StringComparison.OrdinalIgnoreCase)
        ))
    );
