         AutoPersistenceModel mappings = AutoMap
             .AssemblyOf<Order>()
             .IgnoreBase<BaseEntity>()
             .Where(GetAutoMappingFilter)
             .Conventions.Setup(GetConventions())
             .Setup(GetSetup())
             .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
         // this is for std mapping
        //mappings.AddMappingsFromAssembly(
        //        typeof(Northwind.Data.NHibernateMappings.RouteConditionMap).Assembly);
