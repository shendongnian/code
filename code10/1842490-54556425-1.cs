    [Test]
    public void TestFunction()
    {
        int d = 0;
        var mockObject = new Mock<Foo>(1, 2);
        mockObject.Setup(x => x.Func1()).Returns(d);//compilation error
    }
