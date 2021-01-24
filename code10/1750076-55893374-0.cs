    public class MyApiController : ApiController 
    {
        // Makes token data available to any method on a class deriving from MyApiController
        public TokenData Token { get; set; }
        // Override constructor - parse token whenever instance is created
        public MyApiController() 
        {
            // Extract the token data from the User variable (User is pulled in from the base ApiController)
            Token = getTokenDataFromUserPrincipal(User);
        }
        private static TokenData getTokenDataFromUserPrincipal(System.Security.Principal.IPrincipal p)
        {
            ...
        }
    }
