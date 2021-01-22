    [Test]
    public void EnumCastTest()
    {
        Assert.That(MyEnum.Exit.EnumCast(), Is.EqualTo(4));
    }
