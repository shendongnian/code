    public interface IWithUserDetails
    {
        UserDetails UserDetails();
    }
    
    public class ExampleBaseController : Microsoft.AspNetCore.Mvc.Controller, IWithUserDetails
    {
        public UserDetails UserDetails()
        {
            return Request.GetUserDetailsFromHttpHeaders();
        }
    }
