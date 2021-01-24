    [Fact]
    public async Task Test1()
    {
        var m = new Mock<IReadAccess<Foo>>(MockBehavior.Strict);
        m.Setup(p => p.GetAll()).ReturnsAsync(new List<Foo>());
        var result = await m.Object.GetAll();
        m.VerifyAll();
    }
