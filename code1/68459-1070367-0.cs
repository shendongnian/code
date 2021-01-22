    yourstub.AssertWasCalled(
                 x => x.DoSomething(
                    Arg<string>.Is.Equal("value1"), 
                    Arg<someObjectType>.Is.Equal(value2), 
                    Arg<someOtherObjectType>.Is.Anything,   <======== NOTE THIS!
                    Arg<someOtherOtherObjectType>.Is.Equal(value3)
                 )
    );
