    Mapper.CreateMap<ApplicationCreateRequest, ApplicationCreateDTO>()
        .ForMember(g => g.FirstName, opt => opt.MapFrom(src => src.FirstName));
        .ForMember(g => g.LastName, opt => opt.MapFrom(src => src.LastName));
        .ForMember(g => g.Contact, opt => opt.MapFrom(src => Mapper.Map<ContactCreateRequest,ContactCreateDTO>(g.Contact)));
        .ForMember(g => g.Demographic, opt => opt.MapFrom(src => Mapper.Map<DemographicCreateRequest,DemographicCreateDTO>(g.Demographic)));
        .ForMember(g => g.Education, opt => opt.MapFrom(src => Mapper.Map<EducationCreateRequest,EducationCreateDTO>(g.Education)));
        .ForMember(g => g.Work, opt => opt.MapFrom(src => Mapper.Map<WorkCreateRequest,WorkCreateDTO>(g.Work)));
