    myMock.Expect(w =>
        w.MyMethod(**It.IsAny<MyEnum>()**,        
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<System.Exception>(),
            null))
    .Returns(myResult);
