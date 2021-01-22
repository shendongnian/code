    /// <summary>
    ///   The name of the Invoke method of a Delegate.
    /// </summary>
    const string InvokeMethod = "Invoke";
    
    
    /// <summary>
    ///   Get method info for a specified delegate type.
    /// </summary>
    /// <param name = "delegateType">The delegate type to get info for.</param>
    /// <returns>The method info for the given delegate type.</returns>
    public static MethodInfo MethodInfoFromDelegateType( Type delegateType )
    {
    	Contract.Requires( delegateType.IsSubclassOf( typeof( MulticastDelegate ) ), "Given type should be a delegate." );
    
    	return delegateType.GetMethod( InvokeMethod );
    }
