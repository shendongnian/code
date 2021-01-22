    // Setup a dummy list that will be filtered, queried, etc
    var actionList = new List<ActionType>()
    {
        new ActionType() { Name = "debug" },
        new ActionType() { Name = "other" }
    };
    _repository.Expect(x => x.Query<ActionType>()).Return(actionList);
    var result = _service.GetAvailableActions().ToList();
    // Check the logic of GetAvailableActions returns the correct subset 
    // of actionList, etc:
    Assert.That(result.Length, Is.EqualTo(1));
    Assert.That(result[0], Is.EqualTo(actionList[0]);
    _repository.VerifyAllExpectations();
        
