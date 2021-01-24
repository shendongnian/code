    public class UserMappingProfile<TUserDto, TUserDtoKey, TUser, TUserKey> : Profile
        where TUserDto : UserDto<TUserDtoKey>
        where TUser : User<TUserKey>
    {
        public UserMappingProfile()
        {
            CreateMap<TUserDto, TUser>(MemberList.Destination)
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.UserId));
            CreateMap<TUser, TUserDto>(MemberList.Source)
                .ForMember(x => x.UserId, opts => opts.MapFrom(x => x.Id));
        }
    }
    public interface IMapperConfigurationBuilder
    {
        IMapperConfigurationBuilder UseProfile<TUserDto, TUserDtoKey, TUser, TUserKey>()
            where TUserDto : UserDto<TUserDtoKey>
            where TUser : User<TUserKey>;
    }
    public static class MyServiceExtensions
    {
        private class MapperConfigurationBuilder : IMapperConfigurationBuilder
        {
            public HashSet<Type> ProfileTypes { get; } = new HashSet<Type>();
            public IMapperConfigurationBuilder UseProfile<TUserDto, TUserDtoKey, TUser, TUserKey>()
                where TUserDto : UserDto<TUserDtoKey>
                where TUser : User<TUserKey>
            {
                ProfileTypes.Add(typeof(UserMappingProfile<TUserDto, TUserDtoKey, TUser, TUserKey>));
                return this;
            }
        }
        public static IMapperConfigurationBuilder AddMyMapper(this IServiceCollection services)
        {
            var builder = new MapperConfigurationBuilder();
            services.AddSingleton<IConfigurationProvider>(sp => new MapperConfiguration(cfg =>
            {
                foreach (var profileType in builder.ProfileTypes)
                    cfg.AddProfile(profileType);
            }));
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            return builder;
        }
    }
