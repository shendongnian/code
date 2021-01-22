    if (typeof(T).IsSubclassOf(p.DeclaringType))
    {
        MethodInfo baseDefinition = p.GetGetMethod().GetBaseDefinition();
        return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                        .FirstOrDefault(property => property.GetGetMethod().GetBaseDefinition() == baseDefinition);
    }
