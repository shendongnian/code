    [TestMethod]
    public void TestMethod1()
    {
      Assert.AreEqual(1, 
        DynamicSwitch<UnitTest1, Blah, Func<UnitTest1, int>>.
          Resolve(Blah.BlahBlah)(this));
      Assert.AreEqual(125, 
        DynamicSwitch<UnitTest1, Blah, Func<UnitTest1, int>>.
          Resolve(Blah.Blip)(this));
     Assert.AreEqual(125, 
        DynamicSwitch<UnitTest1, Blah, Func<UnitTest1, int>>.
          Resolve(Blah.Bop)(this));
    }
    public enum Blah
    {
     BlahBlah,
     Bloo,
     Blip,
     Bup,
     Bop
    }
    [DynamicSwitchAttribute(typeof(Blah), Blah.BlahBlah)]
    public int Method()
    {
     return 1;
    }
    [DynamicSwitchAttribute(typeof(Blah), Blah.Blip, Blah.Bop)]
    public int Method2()
    {
     return 125;
    }
