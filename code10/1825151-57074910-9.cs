    public class ApplicationUser : IdentityUser
    {
        public PasswordHashVersion HashVersion { get; set; }
        public ApplicationUser()
        {
            this.HashVersion = PasswordHashVersion.Core;
        }
    }
    public enum PasswordHashVersion
    {
        OldMvc,
        Core
    }
