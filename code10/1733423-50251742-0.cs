    builder.RegisterType<Processor>().AsSelf()
        .WithParameter((p, c) => p.Name == "handlers",
            (p, c) => new[] 
                {
                    c.ResolveKeyed<IHandler>(HandlerType.One),
                    c.ResolveKeyed<IHandler>(HandlerType.Three)
                });
