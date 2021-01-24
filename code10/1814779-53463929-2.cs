    public class User : IReadOnlyUser
    {
        // (same as before)
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
