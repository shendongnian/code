    public class MyUsernameTokenManager : UsernameTokenManager {
        protected override string AuthenticateToken(UsernameToken token) {
            // Authenticate here.
            // If succeess, return an authenticated IPrincipal and the user's password as shown.
            // If failure, throw an exception of your choosing.
            token.Principal = principal;
            return password;
        }
    }
