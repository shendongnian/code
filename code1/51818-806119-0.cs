    [TestMethod]
    public void TestFooMethods()
    {
        //Generate a new Mock to test against
        Foo foo = MockRepository.GenerateMock<Foo>();
        //Expect a call to Method1 on object foo and return true
        foo.Expect(f => f.Method1()).Return(true);
        //Expect a call to Method2 on object foo and call the original method
        foo.Expect(f => f.Method2()).CallOriginalMethod(OriginalCallOptions.CreateExpectation);
        Assert.IsTrue(foo.Method2());
        //Verify all our expectations on foo
        foo.VerifyAllExpectations();
    }
