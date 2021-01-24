    public interface IReadOnlyUser
    {
        // Note that the interfaces' properties lack setters.
        String              UserName     { get; }
        IReadOnlyList<Byte> PasswordHash { get; }
        IReadOnlyList<Byte> PasswordSalt { get; }
        // ValidatePassword does not mutate state so it's exposed
        Boolean ValidatePassword(String inputPassword);
        
        // But ResetSalt is not exposed because it mutates instance state
    }
