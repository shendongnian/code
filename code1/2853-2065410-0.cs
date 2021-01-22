    /// <summary>
    /// Generic object copy of the same type
    /// </summary>
    /// <typeparam name="T">The type of object to copy</typeparam>
    /// <param name="ObjectSource">The source object to copy</param>
    public T CopyObject<T>(T ObjectSource)
    {
        T NewObject = System.Activator.CreateInstance<T>();
    
        foreach (PropertyInfo p in ObjectSource.GetType().GetProperties())
            NewObject.GetType().GetProperty(p.Name).SetValue(NewObject, p.GetValue(ObjectSource, null), null);
    
        return NewObject;
    }
