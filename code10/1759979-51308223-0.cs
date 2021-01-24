    [Fact]
    public void HelpMe()
    {
        Assert.ThrowsAny<Exception>(() => {
            var pls = new Span<byte>();
            var plsExplode = pls[-1];
        });
    }
