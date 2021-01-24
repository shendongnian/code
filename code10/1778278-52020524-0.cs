    [Fact]
    public void ChangeProperty1_RaisesNoEvent()
    {
        var instance = new Class();
        bool isInvoked = false;
        instance.RelevantPropertyChanged += (s, e) => isInvoked = true;
        Assert.False(isInvoked);
        instance.Property1 = 5;
        Assert.False(isInvoked);
    }
