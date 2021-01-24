    public class ExampleBaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserDetailsProvider _userDetailsProvider;
        public UserDetails UserDetails => _userDetailsProvider.Get(Request);
    
        public ExampleBaseController(IUserDetailsProvider userDetailsProvider)
        {
            _userDetailsProvider = userDetailsProvider;
        }
    }
