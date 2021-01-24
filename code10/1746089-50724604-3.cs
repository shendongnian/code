    public class DomainProfiles : Profile
    {
        public DomainProfiles()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CustomerShort, opt => opt.MapFrom(src => src.CustomerShort))
                .ForMember(dest => dest.RecordStatus, opt => opt.MapFrom(src => src.RecordStatus));
        }
    }
