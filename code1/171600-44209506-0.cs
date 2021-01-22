        // This is a modification to https://stackoverflow.com/a/7964376/725903
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        private delegate void CpuIDDelegate(int level, IntPtr ptr);
        [StructLayout(LayoutKind.Sequential, Size = 16)]
        public struct CpuIdResult
        {
            public int Eax;
            public int Ebx;
            public int Ecx;
            public int Edx;
        }
        public CpuIdResult Invoke(int level)
        {
            CpuIdResult result;
            IntPtr buffer = Marshal.AllocHGlobal(16);
            try
            {
                this.cpuIdDelg(level, buffer);
                result = (CpuIdResult)Marshal.PtrToStructure(buffer, typeof(CpuIdResult));
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
            return result;
        }
