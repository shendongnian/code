    public void ThisWillWork()
    {
        var source = new DummySource[0];
        var implementor = new Mock<DummyInterface>()
                              .Setup(m => m.A, source.Select(s => s.A))
                              .Setup(m => m.B, source.Select(s => s.C + "_" + s.D))
                              .Object;
        DoSomethingWithDummyInterface(implementor);
    }
