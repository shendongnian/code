    using DWORD = System.UInt32;
    public static class NativeFile
    {
        public struct NativeFileInfo
        {
            public Version Version;
            public NameValueCollection StringTable;
        }
        public unsafe static NativeFileInfo GetFileInfo(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            IntPtr handle;
            var size = GetFileVersionInfoSize(path, out handle);
            var buffer = Marshal.AllocHGlobal(size);
            try
            {
                if (!GetFileVersionInfo(path, handle, size, buffer))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                IntPtr pVersion;
                int versionLength;
                VerQueryValue(buffer, “\”, out pVersion, out versionLength);
                var versionInfo = (VS_FIXEDFILEINFO)Marshal.PtrToStructure(pVersion, typeof(VS_FIXEDFILEINFO));
                var version = new Version((int)versionInfo.dwFileVersionMS >> 16,
                                          (int)versionInfo.dwFileVersionMS & 0xFFFF,
                                          (int)versionInfo.dwFileVersionLS >> 16,
                                          (int)versionInfo.dwFileVersionLS & 0xFFFF);
                // move to the string table and parse
                var pStringTable = ((byte*)pVersion.ToPointer()) + versionLength;
                var strings = ParseStringTable(pStringTable, size – versionLength);
                return new NativeFileInfo
                {
                    Version = version,
                    StringTable = strings
                };
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        private unsafe static NameValueCollection ParseStringTable(byte* pStringTable, int length)
        {
            NameValueCollection nvc = new NameValueCollection();
            byte* p = pStringTable;
            short stringFileInfoLength = (short)*p;
            byte* end = pStringTable + length;
            p += (2 + 2 + 2); // length + valuelength + type
            // verify key
            var key = Marshal.PtrToStringUni(new IntPtr(p), 14);
            if (key != "StringFileInfo") throw new ArgumentException();
            // move past the key to the first string table
            p += 30;
            short stringTableLength = (short)*p;
            p += (2 + 2 + 2); // length + valuelength + type
            // get locale info
            key = Marshal.PtrToStringUni(new IntPtr(p), 8);
            // move to the first string
            p += 18;
            while (p < end)
            {
                short stringLength = (short)*p;
                p += 2;
                short valueChars = (short)*p;
                p += 2;
                short type = (short)*p;
                p += 2;
                if (stringLength == 0) break;
                if ((valueChars == 0) || (type != 1))
                {
                    p += stringLength;
                    continue;
                }
                var keyLength = stringLength – (valueChars * 2) – 6;
                key = Marshal.PtrToStringUni(new IntPtr(p), keyLength / 2).TrimEnd(”);
                p += keyLength;
                var value = Marshal.PtrToStringUni(new IntPtr(p), valueChars).TrimEnd(”);
                p += valueChars * 2;
                if ((int)p % 4 != 0) p += 2;
                nvc.Add(key, value);
            }
            return nvc;
        }
        private const string COREDLL = "coredll.dll";
        [DllImport(COREDLL, SetLastError = true)]
        private static extern int GetFileVersionInfoSize(string lptstrFilename, out IntPtr lpdwHandle);
        [DllImport(COREDLL, SetLastError = true)]
        private static extern bool GetFileVersionInfo(string lptstrFilename, IntPtr dwHandle, int dwLen, IntPtr lpData);
        [DllImport(COREDLL, SetLastError = true)]
        private static extern bool VerQueryValue(IntPtr pBlock, string lpSubBlock, out IntPtr lplpBuffer, out int puLen);
        [StructLayout(LayoutKind.Sequential)]
        private struct VS_FIXEDFILEINFO
        {
            public DWORD dwSignature;
            public DWORD dwStrucVersion;
            public DWORD dwFileVersionMS;
            public DWORD dwFileVersionLS;
            public DWORD dwProductVersionMS;
            public DWORD dwProductVersionLS;
            public DWORD dwFileFlagsMask;
            public DWORD dwFileFlags;
            public FileOS dwFileOS;
            public FileType dwFileType;
            public DWORD dwFileSubtype;
            public DWORD dwFileDateMS;
            public DWORD dwFileDateLS;
        };
        public enum FileOS : uint
        {
            Unknown = 0x00000000,
            DOS = 0x00010000,
            OS2_16 = 0x00020000,
            OS2_32 = 0x00030000,
            NT = 0x00040000,
            WindowsCE = 0x00050000,
        }
        public enum FileType : uint
        {
            Unknown = 0x00,
            Application = 0x01,
            DLL = 0x02,
            Driver = 0x03,
            Font = 0x04,
            VXD = 0x05,
            StaticLib = 0x07
        }
    }
