    public IColoredShape CreateColoredShapeMixin(IHasShape shape, IHasColor color)
    {
    	var options = new ProxyGenerationOptions();
    	options.AddMixinInstance(shape);
    	options.AddMixinInstance(color);
    	var proxy = generator.CreateClassProxy(typeof(object), new[] { typeof(IColoredShape ) }, options) as IColoredShape;
    	return proxy;
    }
