    [TestMethod]
    public void OutputTest()
    {
        var writer = new Mock<TextWriter>(MockBehavior.Strict);
        writer.Setup(x => x.WriteLine("expected output")).Verifiable();
        MySnazzyMethod(writer.Object, "input", 1, 'c');
        writer.Verify();
    }
