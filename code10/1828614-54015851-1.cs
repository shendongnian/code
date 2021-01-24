    class User
    {
        public string Name { get; set; }
    }
    class UserDto
    {
        public string NameDto { get; set; }
    }
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(target => target.NameDto, x => x.MapFrom(source => source.Name))
                .ReverseMap();
        }
    }
   
    internal class Program
    {
       private static void Main(string[] args)
       {
           Mapper.Initialize(config =>
           {
               config.AddProfile<UserProfile>();
           });
           var items = new List<User> { new User { Name = "First name" } };
           var users = new PaginatedList<User>(items, 1, 0, 1);
           var usersDtos = Mapper.Map<PaginatedList<UserDto>>(users);
       }
   }
