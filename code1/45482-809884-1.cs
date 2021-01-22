    [DllImport("uxtheme.dll")]
    public static extern int SetWindowThemeAttribute(IntPtr hWnd, WindowThemeAttributeType wtype, ref WTA_OPTIONS attributes, uint size);
    public enum WindowThemeAttributeType : uint
    {
        /// <summary>Non-client area window attributes will be set.</summary>
        WTA_NONCLIENT = 1,
    }
    public struct WTA_OPTIONS
    {
        public uint Flags;
        public uint Mask;
    }
    public static uint WTNCA_NODRAWCAPTION = 0x00000001;
    public static uint WTNCA_NODRAWICON = 0x00000002;
    
    WTA_OPTIONS wta = new WTA_OPTIONS() { Flags = WTNCA_NODRAWCAPTION | WTNCA_NODRAWICON, Mask = WTNCA_NODRAWCAPTION | WTNCA_NODRAWICON };
    
    SetWindowThemeAttribute(this.Handle, WindowThemeAttributeType.WTA_NONCLIENT, ref wta, (uint)Marshal.SizeOf(typeof(WTA_OPTIONS)));
