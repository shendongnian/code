    [Test]
    public void GetInt()
    {
        var bytes = new byte[] { 0, 0, 2, 1};
        var result = 0;
        foreach (var b in bytes)
        {
            result <<= 7;
            result = result + (b & 0x7f);
        }
        Assert.That(result, Is.EqualTo(257));
    }
    [Test]
    public void SetInt()
    {
        var i = 257;
        var bytes = new Stack<byte>();
        for (var j = 0 ; j < sizeof(int) ; j++)
        {
            var b = (byte)(i & 0x7f);
            bytes.Push(b);
            i >>= 7;
        }
        Assert.That(bytes.Pop(), Is.EqualTo(0));
        Assert.That(bytes.Pop(), Is.EqualTo(0));
        Assert.That(bytes.Pop(), Is.EqualTo(2));
        Assert.That(bytes.Pop(), Is.EqualTo(1));
    }
