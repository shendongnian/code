    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminOnlyAttribute : AuthorizeAttribute 
    {
        public AdminOnlyAttribute(){
             
        }
              
        public override void OnAuthorization(AuthorizationContext filterContext) 
        {
             //Here you will to figure out to 
             //have to access your Context with some DependencyResolver
             //Exemple
             var _context = ISomeInterface.ReturnCurrentContext();
        
             var personLoggedIn = User.Identity.Name.Split('\\')[1]; // Intranet application.. so the domain name comes before the username hence the split
             if(_context.UserTable.Single(x => x.UserLogon == personLoggedIn).IsAdministrator == false)
             {
                return View("Error");
                //Or even
                reuturn new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "You don't have Access")
             }
             base.OnAuthorization(filterContext);
        }         
    }
