    container.Kernel.Register(
        Classes.FromAssembly(typeof(StudentRepository).Assembly)
            .Where(Component.IsInNamespace(typeof(StudentRepository).Namespace, includeSubnamespaces: true))
            .WithServiceAllInterfaces()
            .LifestyleScoped());
