    public IColoredShape CreateColoredShapeMixin(IHasShape shape, IHasColor color)
    {
        var generator = new ProxyGenerator();
        var interceptor = new SomeInterceptor();
        var options = new ProxyGenerationOptions();
        options.AddMininInstance(color);
    
        return generator.CreateCustomProxy(typeof(IColoredShape), options, interceptor);
    }
