    public interface IUserContext {
       bool IsAuthenticated {get;}
       // additional properties like user id / name / etc
    }
    public class UserContext : IUserContext
    {
      public UserContext(HttpContextBase httpContext) {
        this.IsAuthenticated = httpContext.User.Identity.IsAuthenticated;
        // any other properties that you want to use later
      }
    }
