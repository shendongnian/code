    // Using
    static bool IsIComparable(Type thing)
        {
            foreach (Type interfaceType in thing.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof (IComparable<>))
                {
                    Type[] arguments = interfaceType.GetGenericArguments();
                    if (arguments.Length == 1)
                    {
                        if (arguments[0] == thing)
                            return true;
                    }
                }
            }
            return false;
        }
    // This returns an enumerable of compatible types:
    var types = assembly.GetTypes().Where( t => 
       typeof(IThing).IsAssignableFrom(t) &&
       typeof(IAwesome).IsAssignableFrom(t) &&
       IsIComparable(t) );
