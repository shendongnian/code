    public class UserManagementService : IUserManagementService 
    {
       private readonly IHttpContext httpContext;
    
       public UserManagementService (IHttpContext httpContext)
       {
          this.httpContext = httpContext;
       }
    
       
    
       public UserCredentials GetUserDetails()
       {
            
    new services.Models.UserCredentials()
        {
            ClientCode = clientCode,
            UserId = UserId,
            Permissions = UserPermissions
        });
       }
    
    }
