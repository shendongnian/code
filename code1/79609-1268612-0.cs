    var fooMock = MockRepository.GenerateStub<Foo>();
    fooMock.Expect(foo => foo.Method1()).Throw(new Exception());
    
    var actual = fooMock.Method2();
    Assert.IsNull(actual);
    
    fooMock.VerifyAllExpectations();
