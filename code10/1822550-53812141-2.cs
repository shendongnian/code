    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<MySqlContext>(new InjectionConstructor("MySqlGlobalConnectionTest"));
        container.RegisterType<ApplicationContext>(new InjectionConstructor("ApplicationConnectionTest"));
        container.RegisterType<MsSqlReadOnlyContext>(new InjectionConstructor("MsSqlApplicationConnection"));
        container.RegisterType<IUnityOfWork, UnityOfWork>();
    }
