    public class TestBase
    {
        private static Dictionary<string, string> _testUserFormData;
        protected readonly IMapper Mapper;
        protected readonly KodkodDbContext KodkodInMemoryContext;
        protected readonly ClaimsPrincipal ContextUser;
        protected readonly HttpClient Client;
        protected async Task<HttpResponseMessage> LoginAsTestUserAsync()
        {
            return await Client.PostAsync("/api/account/login",
                _testUserFormData.ToStringContent(Encoding.UTF8, "application/json"));
        }
        public TestBase()
        {
            // disable automapper static registration
            ServiceCollectionExtensions.UseStaticRegistration = false;
            // Initialize mapper
            Mapper = new Mapper(
                new MapperConfiguration(
                    configure => { configure.AddProfile<ApplicationMappingProfile>(); }
                )
            );
            Client = GetTestServer();
            _testUserFormData = new Dictionary<string, string>
            {
                {"email", "testuser@mail.com"},
                {"username", "testuser"},
                {"password", "123qwe"}
            };
            KodkodInMemoryContext = GetInitializedDbContext();
            ContextUser = GetContextUser();
        }
    ...
