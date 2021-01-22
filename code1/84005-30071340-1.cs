    [Flags]
    enum Option
    {
        None = 0x00,
        One = 0x01,
        Two = 0x02,
        Three = One | Two,
        Four = 0x04
    }
    [TestMethod]
    public void HasAnyFlag()
    {
        Option o1 = Option.One;
        Assert.AreEqual(true, o1.HasAnyFlag(Option.Three));
        Assert.AreEqual(false, o1.HasFlag(Option.Three));
        o1 |= Option.Two;
        Assert.AreEqual(true, o1.HasAnyFlag(Option.Three));
        Assert.AreEqual(true, o1.HasFlag(Option.Three));
    }
