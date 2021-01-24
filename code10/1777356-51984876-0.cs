    // declare some dummy variables; the names don't matter.
    byte _;
    string __;
    // then use & forget about them.
    myClassMock.Verify(v => v.Method2(It.IsAny<string>(), out _, out __), Times.AtMost(3));
    //                                                    ^^^^^  ^^^^^^
