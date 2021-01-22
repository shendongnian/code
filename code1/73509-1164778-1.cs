    //needs full DP propName, like "WidthProperty"
    public static DependencyProperty FindDependencyProperty(this DependencyObject target, string propName)
    {
        FieldInfo fInfo = target.GetType().GetField(propName, BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
        if (fInfo == null) return null;
        return (DependencyProperty) fInfo.GetValue(null);
    }
    public static bool HasDependencyProperty(this DependencyObject target, DependencyProperty prop)
    {
        return FindDependencyProperty(target, prop.GetType().Name) == prop;
    }
