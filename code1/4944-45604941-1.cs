    public static void DoubleBuffered(Control formControl, bool setting)
    {
        Type conType = formControl.GetType();
        PropertyInfo pi = conType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(formControl, setting, null);
    }
