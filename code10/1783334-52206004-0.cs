    public class UserManagementService : IUserManagementService 
    {
       private readonly IHttpContextAccessor httpContextAccessor;
    
       public UserManagementService (IHttpContextAccessor httpContextAccessor)
       {
          this.httpConntextAccessor = httpContextAccessor;
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
