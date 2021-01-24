    Mapper.Initialize(cfg =>
                      {
                          cfg.CreateMap<A, B>()
                             .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Ids));
                          cfg.CreateMap<int, Category>()
                             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src))
                             .ForAllOtherMembers(opt => opt.Ignore());
                      });
