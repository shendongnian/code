    [Test]
    public void Immutable_Types_Should_Be_Immutable()
    {
      var decorated = GlobalSetup.Types
        .Where(t => t.Has<ImmutableAttribute>());
      foreach (var type in decorated)
      {
        var count = type.GetAllFields().Count(f => !f.IsInitOnly && !f.IsStatic);
        Assert.AreEqual(0, count, "Type {0} should be immutable", type);
      }
    }
