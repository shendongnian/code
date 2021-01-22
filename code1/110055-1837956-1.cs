    private class FinderMock : Finder
    {
      public int numTimesCalled = 0;
      string expected;
      public FinderMock(string expected)
      {
        this.expected = expected;
      }
      public string Search(string arg)
      {
        numTimesCalled++;
        Assert.AreEqual(expected, arg);
      }
    }
