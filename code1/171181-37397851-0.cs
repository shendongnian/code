    Mapper.Initialize(i =>
    {
        i.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
        i.CreateMap<Source, Target>();                
    });
