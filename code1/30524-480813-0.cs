    private const string GlobalContainerKey = "UnityContainerKey";
    private const object lockObject = new object();
    
    public static IUnityContainer GetContainer(this HttpApplicationState application)
    {
        var IUnityContainer container = null;
    
        lock (lockObject)
        {
            container = application[GlobalContainerKey] as IUnityContainer;
            if (container == null)
            {
                container = new UnityContainer();
                application[GlobalContainerKey] = container;
            }
        }
    
        return container;
    }
