    [TestMethod]
    public void Test()
    {
      var enums = (myEnum[])Enum.GetValues(typeof(myEnum));
      Assert.IsTrue(enums.Count() == enums.Distinct().Count());
    }
