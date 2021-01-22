    public static bool LocalVisible(this Control control)
    {
        var flags = typeof (Control)
            .GetField("flags", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(control);
        return ! (bool) flags.GetType()
            .GetProperty("Item", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(flags, new object[] {0x10});
    }
