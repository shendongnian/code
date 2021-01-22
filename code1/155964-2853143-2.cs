    var callerKey = GetStrongName(Assembly.GetCallingAssembly().Evidence).PublicKey;
    var execKey = GetStrongName(Assembly.GetExecutingAssembly().Evidence).PublicKey;
    if (callerKey != execKey)
    {
        throw new UnauthorizedAccessException("The strong name of the calling assembly is invalid.");
    }
