    ForRequestedType<DataContext>()
        .CacheBy(InstanceScope.Hybrid)
        .AddInstances(inst => inst.ConstructedBy(() => 
            new SecondDataContext { Log = new DebuggerWriter() })
            .WithName("secondDataContext"))
        .TheDefault.Is
        .ConstructedBy(() => new FirstDataContext {Log = new DebuggerWriter()});
    ForRequestedType<IRepository<SpecificObject>>()
        .TheDefault.Is
        .OfConcreteType<SqlRepository<SpecificObject>>()
        .CtorDependency<DataContext>()
        .Is(inst => inst.TheInstanceNamed("secondDataContext"));
