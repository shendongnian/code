     public class IdentityUser : IUser
        {
            public IdentityUser();
            public IdentityUser(string userName);
    
            public virtual ICollection<IdentityUserClaim> Claims { get; }
            public virtual string Id { get; set; }
            public virtual ICollection<IdentityUserLogin> Logins { get; }
            public virtual string PasswordHash { get; set; }
            public virtual ICollection<IdentityUserRole> Roles { get; }
            public virtual string SecurityStamp { get; set; }
            public virtual string UserName { get; set; }
        }
