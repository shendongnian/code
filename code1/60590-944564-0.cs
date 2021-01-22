    Type type = candidateAssemblies.Select(assembly => assembly.GetType(typeName))
                                   .Where(type => type != null)
                                   .FirstOrDefault();
    if (type != null)
    {
        // Use it
    }
    else
    {
        // Couldn't find the right type
    }
