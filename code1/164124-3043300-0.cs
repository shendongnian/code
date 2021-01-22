    // note: changed return type to TService to match Func<TService> signature
    private static TService Uninitialized<TService>()
    {
        throw new InvalidOperationException();
    }
    // note: removed () symbols to perform assignment instead of method call
    public static Func<IAuthenticationProvider> AuthenticationProvider = Uninitialized<IAuthenticationProvider>;
    public static Func<IUnitOfWorkFactory> UnitOfWorkFactory = Uninitialized<IUnitOfWorkFactory>;
