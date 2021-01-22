    public static T clone<T>(T original)
    {
        T tempMyClass = (T)Activator.CreateInstance(original.GetType());
        FieldInfo[] fis = original.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (FieldInfo fi in fis)
        {
            object fieldValue = fi.GetValue(original);
            if (fi.FieldType.Namespace != original.GetType().Namespace)
                fi.SetValue(tempMyClass, fieldValue);
            else
                fi.SetValue(tempMyClass, clone(fieldValue));
        }
        return tempMyClass;
    }
