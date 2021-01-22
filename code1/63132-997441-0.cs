     container.Register(
            AllTypes
                .FromAssemblyNamed("Aplication")
                .BasedOn<IController>()
                .Configure(c => c.LifeStyle.Is(LifestyleType.Transient))
                .WithService
                .FirstInterface()
            );
