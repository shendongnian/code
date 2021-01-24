    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetVersionT();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int StartServerT(string ip, int port);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnRemoteErrorT(object caller, int error);
    public struct RemoteServerPluginI
    {
        [MarshalAs(UnmanagedType.FunctionPtr)] public GetVersionT GetVersion;
        [MarshalAs(UnmanagedType.FunctionPtr)] public StartServerT StartServer;
        [MarshalAs(UnmanagedType.FunctionPtr)] public OnRemoteErrorT OnRemoteError;
        // a lot of other methods not shown
    }
