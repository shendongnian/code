    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<LaunchConfiguration, LaunchConfigurationDto>();
            CreateMap<LaunchConfigurationDto, LaunchConfiguration>();
        }
    };
