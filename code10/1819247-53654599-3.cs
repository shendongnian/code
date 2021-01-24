    public class StubUserDetailsOption : IUserDetailsProviderOptions
    {
        public Func<UserDetails> UserDetailsProvider { get; set; } = () => new StubDetails();
    }
    var controller = new ExampleBaseController(new StubUserDetailsOption());
