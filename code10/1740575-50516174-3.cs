    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryOutputModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src =>
                    // Because of your setup, it doesn't guarantee that
                    // there is only one translation came out at the end for a 
                    // language code for a category so I used FirstOrDefalt() 
                    // here.
                    src.Translations.FirstOrDefault()?.Name));
        }
    }
