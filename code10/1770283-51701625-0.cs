    [TestMethod]
    public void MyTestMethod()
    {
        var mock = new Mock<IMyInterface>(MockBehavior.Strict);
        //will fail
        var listOfThings = new List<int> { 5, 4, 3, 2, 1 };
        //will pass
        var listOfOtherThings = new List<int> { 1, 2, 3, 4, 5 };
        var s = new MockSequence();
        mock.InSequence(s).Setup(m => m.Method(1));
        mock.InSequence(s).Setup(m => m.Method(2));
        mock.InSequence(s).Setup(m => m.Method(3));
        mock.InSequence(s).Setup(m => m.Method(4));
        mock.InSequence(s).Setup(m => m.Method(5));
        MethodUnderTest(mock.Object, listOfThings);
        mock.Verify(m => m.Method(1));
        mock.Verify(m => m.Method(2));
        mock.Verify(m => m.Method(3));
        mock.Verify(m => m.Method(4));
        mock.Verify(m => m.Method(5));
    }
