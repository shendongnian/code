    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base(GetConnectionStringName(), throwIfV1Schema: false)
        {
        }
        static string GetConnectionStringName()
        {
             // Your logic for the connectionstring, I use the Request.Url here.
             return HttpContext.Current.Request.Url.Authority.ToLower().Split(new char[] { ':' }).FirstOrDefault().Replace("www.", "");
        }
    }
