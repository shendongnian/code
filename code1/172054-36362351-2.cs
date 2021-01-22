    //ARRANGE
    const string CLASSCODE = "ABC";
    const string SUBCLASSCODE = "123X";
    var expected = new [] {CLASSCODE, SUBCLASSCODE};
    //ACT
    SUT.CallMyFunction(chkMock);
    var actual = chkMock.GetArgumentsForCallsMadeOn(m => m.MustPublish(null, null))[0];
    
    //Assert
    CollectionAssert.AreEqual(expected, actual);
    //instead of
    //chkMock.AssertWasCalled(m => m.MustPublish(Arg<string>.Is.Equal("2"), Arg<string>.Is.Equal(SUBCLASSCODE)));
