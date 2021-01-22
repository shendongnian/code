    public interface ISecurity
    {
        Permissions GetPermissions(Uri resource);
    }
    
    public static class SecurityExtensions
    {
        public static ISecurity Security(this IPerson person)
        {
           return new SecurityImpl(person);
        }
    }
