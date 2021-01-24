    public class GamerMappingProfile : Profile
    {
        public GamerMappingProfile()
        {
            CreateMap<Gamer, GamerVM>();
            CreateMap<GamerVM, Gamer>();
        }
    }
