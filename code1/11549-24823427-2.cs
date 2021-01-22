    public void ThisWillWork()
    {
        var source = new DummySource[0];
        var mock  new Mock<DummyInterface>();
        mock.SetupProperty(m => m.A, source.Select(s => s.A));
        mock.SetupProperty(m => m.B, source.Select(s => s.C + "_" + s.D));
        DoSomethingWithDummyInterface(mock.Object);
    }
