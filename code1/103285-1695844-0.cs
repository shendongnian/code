    // arrange
    var myServiceStub = MockRepository.GenerateStub<IMyService>();
    var myComplexObj = new MyComplexObject 
    {
        SomeProp = "something",
        SomeOtherProp = "something else"
    };
    // act
    myServiceStub.MethodA(myComplexObj, 10);
    // assert
    myServiceStub.AssertWasCalled(
        x => x.MethodA(
            Arg<MyComplexObject>.Matches(
                arg1 => arg1.SomeProp == "something" &&
                        arg1.SomeOtherProp == "something else"
            ), 
            Arg<int>.Is.Equal(10)
        )
    );
