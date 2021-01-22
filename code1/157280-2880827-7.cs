    [TestMethod]
    public void TestMethod2()
    {
      //no longer have any angle brackets
      ActionSwitch.Switch(Blah.Bup).On(this);
      Assert.IsTrue(_actionMethod1Called);
    }
    private bool _actionMethod1Called;
    [DynamicSwitch(typeof(Blah), Blah.Bup)]
    public void ActionMethod1()
    {
      _actionMethod1Called = true;
    }
