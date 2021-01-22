    public static class UserExtensions
    {
        public static string GetDomain(this IIdentity identity)
        {
            Regex.Match(identity.Name, ".*\\\\").ToString()
        }
    
        public static string GetLogin(this IIdentity identity)
        {
            return Regex.Replace(identity.Name, ".*\\\\", "");
        }
    }
