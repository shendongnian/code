    public static FileStream Open(string channelName, WTS_CHANNEL_OPTION option = WTS_CHANNEL_OPTION.DYNAMIC)
    {
        // Open
        SafeFileHandle pFile = null;
        using (var sfh = WTSVirtualChannelOpenEx(WTS_CURRENT_SESSION, channelName, option))
        {
            WtsAllocSafeHandle pBuffer = null;
            try
            {
                int cbReturned;
                if (!WTSVirtualChannelQuery(sfh, WTS_VIRTUAL_CLASS.FileHandle, out pBuffer, out cbReturned)
                    || cbReturned < IntPtr.Size)
                {
                    throw new Win32Exception();
                }
                var pWtsFile = Marshal.ReadIntPtr(pBuffer.DangerousGetHandle());
                if (!DuplicateHandle(
                    GetCurrentProcess(), pWtsFile,
                    GetCurrentProcess(), out pFile, 
                    0, false, DUPLICATE_SAME_ACCESS))
                {
                    throw new Win32Exception();
                }
            }
            finally
            {
                pBuffer?.Dispose();
            }
        }
        // create
        return new FileStream(pFile, FileAccess.ReadWrite, bufferSize: 32 * 1024 * 1024, isAsync: true);
    }
