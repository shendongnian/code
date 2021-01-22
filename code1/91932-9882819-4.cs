    private static SafeFileHandle getFileHandle(string path)
    {
        return CreateFile(path, genericReadAccess, shareModeAll, IntPtr.Zero, openExisting,
            fileFlagsForOpenReparsePointAndBackupSemantics, IntPtr.Zero);
    }
 
    public static string GetTarget(string path)
    {
        SymbolicLinkReparseData reparseDataBuffer;
 
        using (SafeFileHandle fileHandle = getFileHandle(path))
        {
            if (fileHandle.IsInvalid)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
 
            int outBufferSize = Marshal.SizeOf(typeof(SymbolicLinkReparseData));
            IntPtr outBuffer = IntPtr.Zero;
            try
            {
                outBuffer = Marshal.AllocHGlobal(outBufferSize);
                int bytesReturned;
                bool success = DeviceIoControl(
                    fileHandle.DangerousGetHandle(), ioctlCommandGetReparsePoint, IntPtr.Zero, 0,
                    outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);
 
                fileHandle.Close();
 
                if (!success)
                {
                    if (((uint)Marshal.GetHRForLastWin32Error()) == pathNotAReparsePointError)
                    {
                        return null;
                    }
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
 
                reparseDataBuffer = (SymbolicLinkReparseData)Marshal.PtrToStructure(
                    outBuffer, typeof(SymbolicLinkReparseData));
            }
            finally
            {
                Marshal.FreeHGlobal(outBuffer);
            }
        }
        if (reparseDataBuffer.ReparseTag != symLinkTag)
        {
            return null;
        }
 
        string target = Encoding.Unicode.GetString(reparseDataBuffer.PathBuffer,
            reparseDataBuffer.PrintNameOffset, reparseDataBuffer.PrintNameLength);
 
        return target;
    }
