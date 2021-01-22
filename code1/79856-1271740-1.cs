    [TestInitialize(), DebuggerStepThrough]
    public void Setup()
    {
      MyEntityExtensions_Accessor._repository = new Mock<IRepository>();
    }
