    ExampleEvent eventPublished = null;
    eventAggregator.Publish(Arg.Do<ExampleEvent>(x => eventPublished = x), Arg.Any<Action<System.Action>>());
    //ACT
    _uut.ExampleMethod();
  
    //ASSERT
    MyTestFramework.Assert.CollectionsEqual(
        new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        eventPublished.Samples);
