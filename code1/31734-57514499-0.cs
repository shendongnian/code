    public static bool Implements(this Type @this, Type @interface)
    {
        if (@this == null || @interface == null) return false;
        return @interface.GenericTypeArguments.Length>0
            ? @interface.IsAssignableFrom(@this)
            : @this.GetInterfaces().Any(c => c.Name == @interface.Name);
    }
