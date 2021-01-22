    [TestMethod]
    public void ReleaseTest()
    {
        // arrange
        WindsorContainer container = new WindsorContainer();
        container.Kernel.ReleasePolicy = new NoTrackingReleasePolicy();
        container.AddComponentWithLifestyle<ReleaseTester>(LifestyleType.Transient);
        var target = container.Resolve<ReleaseTester>()
        
        // act
        target = null;
        // assert        
        dotMemory.Check(memory =>
          Assert.AreEqual(
            0, 
            memory.GetObjects(where => where.Type.Is<ReleaseTester>().ObjectsCount, 
            "Component not released");
    }
