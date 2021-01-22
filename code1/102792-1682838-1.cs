    // arrange
    IDictionary<string, string> someDictionary = new Dictionary<string, string> {
      { "Key1", "Value1" },
      { "Key2", "Value2" }
    };
    ISomeService someService = MockRepository.GenerateStub<ISomeService>();
    
    // act: someService needs to be the mocked object
    // so invoke the desired method somehow
    // this is usually done through the real subject under test
    someService.GetCodes(someDictionary);
    
    // assert
    someService.AssertWasCalled(
        x => x.GetCodes(someDictionary)
    );
