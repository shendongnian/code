    ConfigurationStore store 
       = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
    store.AssertConfigurationIsValid();
    MappingEngine engine = new MappingEngine(store);
    //add mappings via Profiles or CreateMap
    store.AddProfile<MyAutoMapperProfile>();
    store.CreateMap<Dto.Ticket, Entities.Ticket>();
