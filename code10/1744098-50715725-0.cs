    public static void RegisterServices(this IUnityContainer container, IConfiguration configuration)
    {
        // Microsoft.Practices.Unity
        var currentContainer = new UnityContainer();
        // Bootstrap this and register dependencies
        // Then copy them over
        foreach (var registration in currentContainer.Registrations)
        {
            container.RegisterType(registration.RegisteredType, registration.MappedToType);
        }
    }
