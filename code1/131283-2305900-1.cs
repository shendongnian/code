    [TestMethod]
    public void SomeClassToTest_SomeMethodToTest()
    {
        // arrange
        var depStub = MockRepository.CreateStub<ISomeDependentObject>();
        var sut = new SomeClassToTest(depStub);
        depStub.Stub(x => x.Method1()).Return(1);
        depStub.Stub(x => x.Method2()).Return(2);
    
        // act
        var actual = sut.SomeMethodToTest();
    
        // assert
        Assert.AreEqual(3, actual);
    }
