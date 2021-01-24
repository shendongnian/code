        RegisterType(new UnityContainer());
    }
    public static void RegisterType(IUnityContainer container)
    {
        container.RegisterType<IBlogRepository, BlogRepository>();
        container.RegisterType<IPostRepository, PostRepository>();
        Application.Run(container.Resolve<Form1>());
    }
