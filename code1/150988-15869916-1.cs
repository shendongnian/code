    // Configuration
    var platformSpecificRegistry = AutoMapper.Internal.PlatformAdapter.Resolve<IPlatformSpecificMapperRegistry>();
    platformSpecificRegistry.Initialize();
    var autoMapperCfg = new AutoMapper.ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
    var mappingEngine = new AutoMapper.MappingEngine(_autoMapperCfg);
