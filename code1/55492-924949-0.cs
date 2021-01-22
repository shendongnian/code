    public bool IsValidWrapper(Type entityType)
    {
        // You may want to be stricter than this, but the essence is to
        // get a handle to the generic method first...
        MethodInfo genMethod = GetType().GetMethod("IsValid");
        // Bind it to the type you want to operate on...
        MethodInfo method = genMethod.MakeGenericMethod(entityType);
        // And invoke it...
        return (bool) method.Invoke(this, null);
    }
