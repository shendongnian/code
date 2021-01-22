    private IUnityContainer unityContainer;
    [Dependency]
    public IUnityContainer UnityContainer
    {
        get { return unityContainer; }
        set { unityContainer = value; }
    }
