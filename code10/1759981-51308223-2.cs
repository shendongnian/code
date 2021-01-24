    [Fact]
    public void HelpMe()
    {
        bool reachedThrowingPart = false;
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var span = new Span<byte>();
            reachedThrowingPart = true;
            var ignored = span[-1];
        });
        Assert.True(reachedThrowingPart);
    }
