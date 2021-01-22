    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var rootObjectProvider = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
        var root = rootObjectProvider.RootObject;
        // do whatever you need to do here
    }
