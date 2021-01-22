    using System.Runtime.InteropServices; // DllImport
    public class Win32 {
      [DllImport("User32.Dll")]
      public static extern void SetWindowText(int h, String s);
    }
