    public static DependencyProperty FindDependencyProperty(this DependencyObject target, string propName)
    {
        FieldInfo fInfo = target.GetType().GetField(string.Format("{0}Property", propName), BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
        if (fInfo == null) return null;
        return (DependencyProperty) fInfo.GetValue(null);
    }
    public static bool HasDependencyProperty(this DependencyObject target, DependencyProperty prop)
    {
        return FindDependencyProperty(target, prop.Name) == prop;
    }
