    [DirectoryObjectClass("user")]
    [DirectoryRdnPrefix("CN")]
    public class UserPrincipalExtended : UserPrincipal
    {
        public UserPrincipalExtended(PrincipalContext context) : base(context)
        {
            // Set ObjectCategory to user so computer objects are not returned
            ExtensionSet("objectCategory", "user");
        }
        [DirectoryProperty("Initials")]
        public string Initials
        {
            get
            {
                if (ExtensionGet("initials").Length != 1) return null;
                return (string)ExtensionGet("initials")[0];
            }
            set { ExtensionSet("initials", value); }
        }
    }
