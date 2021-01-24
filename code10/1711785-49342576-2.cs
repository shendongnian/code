    public static class EntityMap
    {
        public static IMapper EntityMapper { get; set; }
        static EntityMap()
        {
            EntityMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<PartEntity, PartModel>();
                config.CreateMap<PartEntityInformation, PartModel>();
            }).CreateMapper();
        }
    }
