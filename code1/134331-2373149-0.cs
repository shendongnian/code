    // arrange
    var view = MockRepository.GenerateMock<IFooView>();
    var bars = new[] { "bars" };
    
    // act
    view.Bars = bars;
    
    // assert
    view.AssertWasCalled(
        x => { x.Bars = bars; }
    );
