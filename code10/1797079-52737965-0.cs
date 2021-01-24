     public class Authorize2 : AuthorizeAttribute
     { 
         private readonly IPermissions _permissions;
         public Authorize2(IPermissions permissions)
         {
                 this._permissions=permissions;
         }
         public override void OnAuthorization(HttpActionContext actionContext)
         {
              var perm = _permissions.hasPermission();
         }
      }
