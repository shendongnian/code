    public enum RoleType
    {
        //All roles must be set to powers of 2
        [Description("Allows access to public information")] Guest = 0,
        [Description("Allows access to the blog")] BlogReader = 4,
    }
