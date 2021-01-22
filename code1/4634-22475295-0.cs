    using System.Runtime.InteropServices;
...
    public static string GetMimeFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException(filename + " not found");
        const int maxContent = 256;
        var buffer = new byte[maxContent];
        using (var fs = new FileStream(filename, FileMode.Open))
        {
            if (fs.Length >= maxContent)
                fs.Read(buffer, 0, maxContent);
            else
                fs.Read(buffer, 0, (int) fs.Length);
        }
        var mimeTypePtr = IntPtr.Zero;
        try
        {
            var result = FindMimeFromData(IntPtr.Zero, null, buffer, maxContent, null, 0, out mimeTypePtr, 0);
            if (result != 0)
            {
                Marshal.FreeCoTaskMem(mimeTypePtr);
                throw Marshal.GetExceptionForHR(result);
            }
            var mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            return mime;
        }
        catch (Exception e)
        {
            if (mimeTypePtr != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(mimeTypePtr);
            }
            return "unknown/unknown";
        }
    }
    [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
    private static extern int FindMimeFromData(IntPtr pBC,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] pBuffer,
        int cbSize,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
        int dwMimeFlags,
        out IntPtr ppwzMimeOut,
        int dwReserved);
