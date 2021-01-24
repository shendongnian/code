    public delegate int GetVersionT();
    public delegate int StartServerT(string ip, int port);
    public delegate void OnRemoteErrorT(object caller, int error);
    public struct RemoteServerPluginI
    {
        [MarshalAs(UnmanagedType.FunctionPtr)] public GetVersionT GetVersion;
        [MarshalAs(UnmanagedType.FunctionPtr)] public StartServerT StartServer;
        [MarshalAs(UnmanagedType.FunctionPtr)] public OnRemoteErrorT OnRemoteError;
        // a lot of other methods not shown
    }
