    public static BindingBase CloneBinding(BindingBase bindingBase, BindingMode mode = BindingMode.Default)
    {
        var cloneMethodInfo = typeof(BindingBase).GetMethod("Clone", BindingFlags.Instance | BindingFlags.NonPublic);
        return (BindingBase) cloneMethodInfo.Invoke(bindingBase, new object[] { mode });
    }
