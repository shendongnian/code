    // This structure will contain information about the file
    public struct SHFILEINFO
    {
        // Handle to the icon representing the file
        public IntPtr hIcon;
        // Index of the icon within the image list
        public int iIcon;
        // Various attributes of the file
        public uint dwAttributes;
        // Path to the file
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szDisplayName;
        // File type
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };
