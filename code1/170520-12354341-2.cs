    public static bool MightBeCSharpCompilerGenerated(
        this ConstructorInfo constructor)
    {
        // Validate parmaeters.
        if (constructor == null) throw new ArgumentNullException("constructor");
        
        // If the method is static, throw an exception.
        if (constructor.IsStatic)
            throw new ArgumentException("The constructor parameter must be an " +
                "instance constructor.", "constructor");
        // Get the body.
        byte[] body = constructor.GetMethodBody().GetILAsByteArray();
