    [Test]
    public void SpecialTest()
    {
      IFoo foo = MockRepository.GenerateStub<IFoo>();
      foo.Stub(f => f.DoSomething(42)).Return(43);
      ...
    }
