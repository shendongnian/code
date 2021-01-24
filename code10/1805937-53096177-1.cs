    foreach (var member in type.GetMembers(System.Reflection.BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField))
    {
        if (member is FieldInfo fi)
        {
        }
        else if (member is PropertyInfo pi)
        {
        }
    }
