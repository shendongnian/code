    public delegate void SetEnabledStateCallBack(Control control, bool enabled);
    public static void SetEnabledState(Control control, bool enabled)
    {
        if (control.InvokeRequired)
        {
            SetEnabledStateCallBack d = new SetEnabledStateCallBack(SetEnabledState);
            control.Invoke(d, new object[] { control, enabled });
        }
        else
        {
            control.Enabled = enabled;
        }
    }
