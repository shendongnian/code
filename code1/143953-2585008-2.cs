    public delegate GraphicsDeviceManager GdmFactory(MasterEngine engine); 
    public delegate GamerServicesComponent GscFactory(MasterEngine engine); 
    ...
    Bind<GdmFactory>()
       .ToMethod(context => engine => new GraphicsDeviceManager(engine));
    Bind<GscFactory>()
       .ToMethod(context => engine => new GamerServicesComponent(engine));
    ...
    public MasterEngine(IInputReader inputReader, 
        GdmFactory graphicsDeviceFactory,
        GscFactory gamerServicesFactory)
    {
        ...
    }
