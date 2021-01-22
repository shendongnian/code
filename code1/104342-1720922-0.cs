    public static class UnmanagedCode
    {
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        //etc...
    
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return:MarshalAs(UnmanagedType.Error)]
        public static extern int CoInternetSetFeatureEnabled(
            int FeatureEntry,
            [MarshalAs(UnmanagedType.U4)] int dwFlags,
            bool fEnable);
    }
