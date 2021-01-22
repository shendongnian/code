    public static unsafe FileVersionInfo GetVersionInfo(string fileName)
    {
        // ...
        int fileVersionInfoSize = UnsafeNativeMethods.GetFileVersionInfoSize(fileName, out num);
        FileVersionInfo info = new FileVersionInfo(fileName);
        if (fileVersionInfoSize != 0)
        {
            byte[] buffer = new byte[fileVersionInfoSize];
            fixed (byte* numRef = buffer)
            {
                IntPtr handle = new IntPtr((void*) numRef);
                if (!UnsafeNativeMethods.GetFileVersionInfo(fileName, 0, fileVersionInfoSize, new HandleRef(null, handle)))
                {
                    return info;
                }
                int varEntry = GetVarEntry(handle);
                if (!info.GetVersionInfoForCodePage(handle, ConvertTo8DigitHex(varEntry)))
                {
                    int[] numArray = new int[] { 0x40904b0, 0x40904e4, 0x4090000 };
                    foreach (int num4 in numArray)
                    {
                        if ((num4 != varEntry) && info.GetVersionInfoForCodePage(handle, ConvertTo8DigitHex(num4)))
                        {
                            return info;
                        }
                    }
                }
            }
        }
        return info;
    }
