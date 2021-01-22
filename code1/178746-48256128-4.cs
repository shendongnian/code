    [SetUp]
    public void TestInit() {
        EventMock = new Mock<AssertEvent>();
        Evt= EventMock.Object;
    }
