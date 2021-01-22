    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    static class GacUtil {
    
        public static void InstallAssembly(string path, bool forceRefresh) {
            IAssemblyCache iac = null;
            CreateAssemblyCache(out iac, 0);
            try {
                uint flags = forceRefresh ? 2u : 1u;
                int hr = iac.InstallAssembly(flags, path, IntPtr.Zero);
                if (hr < 0) Marshal.ThrowExceptionForHR(hr);
            }
            finally {
                Marshal.FinalReleaseComObject(iac);
            }
        }
    
        public static void UninstallAssembly(string displayName) {
            IAssemblyCache iac = null;
            CreateAssemblyCache(out iac, 0);
            try {
                uint whatHappened;
                int hr = iac.UninstallAssembly(0, displayName, IntPtr.Zero, out whatHappened);
                if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                switch (whatHappened) {
                    case 2: throw new InvalidOperationException("Assembly still in use");
                    case 5: throw new InvalidOperationException("Assembly still has install references");
                    case 6: throw new System.IO.FileNotFoundException();    // Not actually raised
                }
            }
            finally {
                Marshal.FinalReleaseComObject(iac);
            }
        }
    
    
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
        internal interface IAssemblyCache {
            [PreserveSig]
            int UninstallAssembly(uint fags, [MarshalAs(UnmanagedType.LPWStr)] string assemblyName, IntPtr pvReserved, out uint pulDisposition);
            [PreserveSig]
            int QueryAssemblyInfo(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pAsmInfo);
            [PreserveSig]
            int CreateAssemblyCacheItem(/* arguments omitted */);
            [PreserveSig]
            int CreateAssemblyScavenger(out object ppAsmScavenger);
            [PreserveSig]
            int InstallAssembly(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszManifestFilePath, IntPtr pvReserved);
        }
    
        [DllImport("mscorwks.dll", PreserveSig = false)]
        internal static extern void CreateAssemblyCache(out IAssemblyCache ppAsmCache, int reserved);
    } 
