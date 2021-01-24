    [Fact]
    public static void GotExpectedEvent()
    {
        var x = new RaisingClass();
        var evt = Assert.RaisesAny<EventArgs>(
            h => x.Completed += h,
            h => x.Completed -= h,
            () => x.RaiseWithArgs(EventArgs.Empty));
    
        Assert.NotNull(evt);
        Assert.Equal(x, evt.Sender);
        Assert.Equal(EventArgs.Empty, evt.Arguments);
    }
