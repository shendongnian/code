    /// <summary>
    /// Returns whether or not the specified class or interface type implements the specified interface.
    /// </summary>
    /// <param name="implementor">The class or interface that might implement the interface.</param>
    /// <param name="interfaceType">The interface to look for.</param>
    /// <returns><b>true</b> if the interface is supported, <b>false</b> if it is not.</returns>
    public static bool ImplementsInterface(this Type implementor, Type interfaceType)
    {
        if (interfaceType.IsGenericTypeDefinition)
        {
            return (implementor.IsGenericType && implementor.GetGenericTypeDefinition() == interfaceType) ||
                (implementor.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType));
        }
        else return interfaceType.IsAssignableFrom(implementor);
    }
