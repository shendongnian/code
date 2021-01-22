    container.Register(
       AllTypes.FromAssemblyInDirectory(new AssemblyFilter("Modules"))
          .Where(t=>t.Namespace.EndsWith(".Services"))
          .WithService.DefaultInterface()
    );
