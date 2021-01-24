    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserView>()
              .ConstructUsing(src => new UserView(src.Id, src.Name, src.Email, src.UserRole));
        }
    }
