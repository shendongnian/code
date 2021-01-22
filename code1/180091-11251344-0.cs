    static class LibVlc
        {
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray,
              ArraySubType = UnmanagedType.LPStr)] string[] argv);
    
            [DllImport("libvlc", CallingConvention = CallingConvention.Cdecl)]
            public static extern void libvlc_release(IntPtr instance);
        }
