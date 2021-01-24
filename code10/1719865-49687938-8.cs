    public interface IAuthenticationProvider : IFormsAuthentication {
        void CheckAuthorizationForUrl(string url);
        
        //...other members
    }
    
    public class AuthenticationProvider : IAuthenticationProvider {
    
        //...
        
    }
    
