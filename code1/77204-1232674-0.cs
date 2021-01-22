    myMock.Expect(w =>
        w.MyMethod(**MyEnum.Value**,
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<System.Exception>(),
            null))
    .Returns(myResult);
