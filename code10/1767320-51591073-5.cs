    public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IUserRepository userRepository;
        public ConfigureMvcOptions(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Configure(MvcOptions options)
        {
            var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
            options.Filters.Add(new RolesAuthorizationFilter(userRepository));
        }
    }
