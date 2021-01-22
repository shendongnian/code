    object currentObj = ...;  // get the object
    Type[] typeArguments;
    if (currentObj.GetType().TryGetInterfaceGenericParameters(typeof(IEnumerable<>), out typeArguments))
    {
        var innerType = typeArguments[0];
        // currentObj implements IEnumerable<innerType>
    }
    else
    {
        // The type does not implement IEnumerable<T> for any T
    }
