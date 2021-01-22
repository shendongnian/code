      try
      {
        command.DoWork();
        Assert.Fail("ArgumentException Expected");
      }
      catch (ArgumentException e)
      {
        Assert.AreEqual("Expected Message", e.Message);
      }
