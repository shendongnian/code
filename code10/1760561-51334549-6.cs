    public static IUnityContainer CompositionRoot()
    {
        var container = new Unity.UnityContainer();
        container.RegisterType<Application>();
        container.RegisterType<Task<HttpClient>>
        (
            new DelegateInjectionFactory
            (
                new Func<Task<HttpClient>>
                (
                    async () => await Create()
                )
            )
        );
        return container;
    }
    public static async Task<HttpClient> Create()
    {
        await Task.Delay(1);  //Simulate doing something asynchronous
        return new HttpClient();
    }
