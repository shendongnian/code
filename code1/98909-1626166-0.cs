    [Guid("fab51c92-95c3-4468-b317-7de4d7588254"), ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface nsICacheEntryInfo
    {
        IntPtr clientID { get; }
        IntPtr deviceID { get; }
        IntPtr key { get; }
        int fetchCount { get; }
        uint lastFetched { get; }
        uint lastModified { get; }
        uint expirationTime { get; }
        uint dataSize { get; }
        [return: MarshalAs(UnmanagedType.Bool)]
        bool isStreamBased();
    }
