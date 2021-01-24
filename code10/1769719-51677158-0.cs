    public class MapModelEntity
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(config =>
            {
              config.CreateMap<StatusEntity, StatusTypeModel>().ReverseMap(); // For bothways
              config.CreateMap<Vehicle, VehicleDto>() // For custom mapping
                    .ForMember(dest => dest.Prop1,
                               opts => opts.MapFrom(src => src.Prop1)); 
            }
