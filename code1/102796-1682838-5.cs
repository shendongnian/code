    someService.AssertWasCalled(
        x => x.GetCodes(
            Arg<IDictionary<string, string>>.Matches(
                dictionary => 
                    dictionary.All(pair => someDictionary[pair.Key] == pair.Value)
            )
        )
    );
