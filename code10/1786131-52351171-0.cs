    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<BackUpMechanismA>().Keyed<IFileBackup>("A");
        builder.RegisterType<BackUpMechanismB>().Keyed<IFileBackup>("B");
        builder.RegisterType<Caller>()
                .WithParameter((p, ctx) => p.Position == 0, (p, ctx) => ctx.ResolveKeyed<IFileBackup>("A"))
                .WithParameter((p, ctx) => p.Position == 1, (p, ctx) => ctx.ResolveKeyed<IFileBackup>("B"));
        IContainer container = builder.Build();
        var caller = container.Resolve<Caller>();
        Console.ReadKey();
    }
