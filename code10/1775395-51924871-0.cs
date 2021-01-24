            public AutoMapperProfile()
        {
            CreateMap<DTO, Model>()
                .ForMember(dest => dest.NavigationPropertyModel, opt => opt.MapFrom(src => src.InnerDTO));
            CreateMap<InnerDTO, NavigationPropertyModel>();
        }
