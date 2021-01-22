	public static TIntf CreateMixinWithTarget<TIntf>(TIntf target, params object[] instances) where TIntf : class{
		ProxyGenerator generator = new ProxyGenerator();
		ProxyGenerationOptions options = new ProxyGenerationOptions();
		instances.ToList().ForEach(obj => options.AddMixinInstance(obj));
		return generator.CreateInterfaceProxyWithTarget <TIntf>(target, options);
	}
    [Test]
    public void Should_extend_any_object()
    {
        var thing = new Something { Name = "Hello World!"};
        var extended = CreateMixinWithTarget<ISomething>(thing, new WithId(), new GuidImpl());
        Assert.IsTrue(extended is IWithId);
        Assert.IsTrue(extended.Id is Guid);
        Assert.IsTrue(extened.Name == "Hello World!");
    }
