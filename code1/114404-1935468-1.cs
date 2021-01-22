    [Test]
    public void Test()
    {
        byte b1 = 0x5a;
        byte b2 = 0x25;
        var combine = Combine(b1, b2);
        Assert.That(combine, Is.EqualTo(0x5a25));
    }
