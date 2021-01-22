    [Test]
    public void testDrilledHole()
    {
      Hole hole = new Hole();
      hole.HoleType = HoleTypes.Drilled;
      Assert.AreEqual(Visibility.Collapsed, hole.HoleDecorator.Visibility);
    }
