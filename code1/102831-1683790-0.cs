    public enum enumA { one, two }
    public enum enumB { one, two }
    [Test]
    public void PreTest()
    {
            Assert.AreEqual((int)enumA.one,(int)enumB.one);
            Assert.AreSame(enumA.one, enumB.one);
    }
