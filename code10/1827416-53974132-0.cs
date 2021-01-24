    public class AutoMapperPresentationProfile : Profile
    {
        public void RegisterMaps()
        {
            CreateMap<WeatherModel, MainViewModel>()
                .ForMember(dest => dest.TemperatureUom, x => x.MapFrom(src => src.TemperatureUom.ToString()));
    
            CreateMap<TrafficModel, MainViewModel>()
                .ConvertUsing<TrafficModelConverter>();
    
            // More mappings
            ...
        }
    }
