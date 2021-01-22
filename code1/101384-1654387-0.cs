    public class PointAuthorizeAttribute : AuthorizeAttribute
    {
        public int PointsRequired { get; set; }
    
        protected override bool AuthorizeCore( HttpContextBase httpContext )
        {
             if (base.AuthorizeCore( httpContext ))
             {
                 var name = httpContext.User.Identity.Name;
                 using (var db = new SomeDataContext())
                 {
                     var userPoints = db.Users
                                        .Where( u => u.UserName == name )
                                        .Select( u => u.Points )
                                        .SingleOrDefault();
                 }
                 return (userPoints >= PointsRequired);
             }
             return false;
        }
    }
