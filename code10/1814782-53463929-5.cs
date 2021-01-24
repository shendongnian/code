    public class User : IReadOnlyUser
    {
        // (same as before, except need to expose IReadOnlyList<Byte> versions of array properties:
        IReadOnlyList<Byte> IReadOnlyUser.PasswordHash => this.PasswordHash;
        IReadOnlyList<Byte> IReadOnlyUser.PasswordSalt => this.PasswordSalt;
    }
    public static void DoReadOnlyStuffWithUser( IReadOnlyUser user )
    {
        ...
    }
    // This method still uses `User` instead of `IReadOnlyUser` because it mutates the instance.
    public static void WriteStuffToUser( User user )
    {
        ...
    }
