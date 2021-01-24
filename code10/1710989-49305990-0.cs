        public static class AutoMapperConfig
        {
            public static IMapper EntityMapper { get; set; }
            static EntityMap()
            {
                EntityMapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Shop, SearchViewModel>()
                        .ForMember(x => x.Title, opts => opts.MapFrom(x => x.TITLE))
                        .ForMember(x => x.Subtitle, opts => opts.MapFrom(x => x.SUB_TITLE))
                        .ForMember(x => x.ProductType, opts => opts.MapFrom(x => x.PRODUCT_TYPE))
                        .ForMember(x => x.Language, opts => opts.MapFrom(x => x.PRODUCT_LANGUAGE))
                        .ForMember(x => x.Description, opts => opts.MapFrom(x => x.BRIEF_DESC));
                });
            }
        }
