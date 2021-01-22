    public static TOut GetShallowCloneByReflection<TOut>(this Object objIn) 
    {
        Type inputType = objIn.GetType();
        Type outputType = typeof(TOut);
        if (!outputType.IsSubclassOf(inputType)) throw new ArgumentException(String.Format("{0} is not a sublcass of {1}", outputType, inputType));
        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        FieldInfo[] fields = inputType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        TOut objOut = (TOut)Activator.CreateInstance(typeof(TOut));
        foreach (PropertyInfo property in properties)
        {
            try
            {
                property.SetValue(ClassInstance, property.GetValue(Object, null), null);
            }
            catch (ArgumentException) { } // For Get-only-properties
        }
        foreach (FieldInfo field in fields)
        {
            field.SetValue(objOut, field.GetValue(objIn));
        }
        return objOut;
    }
