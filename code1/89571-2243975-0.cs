    StructureMap.ObjectFactory.Initialize(x =>
    {
        x.Scan(scan =>
        {
            scan.TheCallingAssembly();
            scan.AddAllTypesOf<IWriter>();
        });
        x.ForRequestedType<IEnumerable<IWriter>>()
            .TheDefault.Is.ConstructedBy(x => ObjectFactory.GetAllInstances<IWriter>());
    });
