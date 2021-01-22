    public class External
    {
      [StructLayout(LayoutKind.Sequential)]
      public struct ICONINFO
      {
        public bool IsIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr MaskBitmap;
        public IntPtr ColorBitmap;
      };
    
      [DllImport("user32.dll")]
      public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);
    
      [DllImport("user32.dll")]
      public static extern IntPtr CreateIconIndirect([In] ref ICONINFO piconinfo);
    
      [DllImport("gdi32.dll")]
      public static extern bool DeleteObject(IntPtr hObject);
    
      [DllImport("gdi32.dll")]
      public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
    }
