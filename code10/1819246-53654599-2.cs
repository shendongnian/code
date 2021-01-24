    public interface IUserDetailsProviderOptions
    {
        Func<UserDetails> UserDetailsProvider { get; set; }
    }
    public class DefaultUserDetailsProviderOptions : IUserDetailsProviderOptions
    {
        public Func<UserDetails> UserDetailsProvider {get; set;}
    }
    public class ExampleBaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Func<UserDetails> _userDetailsProvider;
        public UserDetails UserDetails => _userDetailsProvider();
        public ExampleBaseController(IUserDetailsProviderOptions options)
        {
             _userDetailsProvider = options.UserDetailsProvider ??
                                  Request.GetUserDetailsFromHttpHeaders;
        }
    }
