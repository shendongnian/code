    public MasterEngine(IInputReader inputReader, 
        Func<Game,GraphicsDeviceManager> graphicsDeviceFactory,
        Func<Game,GamerServicesComponent> gamerServicesFactory)
    {
        this.inputReader = inputReader;
        graphicsDeviceManager = graphicsDeviceFactory(this);
        Components.Add(gamerServicesFactory(this));
    }
