    [MarshalAs(UnmanagedType.FunctionPtr)]
    private IntPtr _callback;    /* 8 */
    public DeviceRestoreNotificationCallback callback {
        get { return (DeviceRestoreNotificationCallback)Marsal.GetDelagateFromFunctionPointer(_callback, typeof(DeviceRestoreNotificationCallback)); }
        set { _calback = Marshal.GetFunctionPointerFromDelegate(value); }
    }
