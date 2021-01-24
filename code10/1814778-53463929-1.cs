    public interface IReadOnlyUser
    {
        // Note that the interfaces' properties lack setters.
        String UserName     { get; }
        Byte[] PasswordHash { get; }
        Byte[] PasswordSalt { get; }
        // ValidatePassword does not mutate state so it's exposed
        Boolean ValidatePassword(String inputPassword);
        
        // But ResetSalt is not exposed because it mutates instance state
    }
