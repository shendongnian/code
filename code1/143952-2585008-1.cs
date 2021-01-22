    public MasterEngine(IInputReader inputReader, 
        Func<MasterEngine,GraphicsDeviceManager> graphicsDeviceFactory,
        Func<MasterEngine,GamerServicesComponent> gamerServicesFactory)
    {
        this.inputReader = inputReader;
        graphicsDeviceManager = graphicsDeviceFactory(this);
        Components.Add(gamerServicesFactory(this));
    }
