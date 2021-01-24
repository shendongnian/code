    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<int>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int? SuperiorID { get; set; }
            public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            } 
            public async Task<ClaimsIdentity>
                GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
            {
                var userIdentity = await manager
                    .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                return userIdentity;
            }
    
            public virtual ApplicationUser Superior { get; set; }
    
        } 
