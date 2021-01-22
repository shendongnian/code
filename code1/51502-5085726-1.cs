    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    class Program
    {
      private const int MAX_PATH = 260;
      private const int CSIDL_DESKTOP = 0x0000; 
      [DllImport("shell32.dll")]
      private static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, int nFolder, bool fCreate);
      static string GetDesktopPath()
      {
        StringBuilder currentUserDesktop = new StringBuilder(MAX_PATH);
        SHGetSpecialFolderPath((IntPtr)0, currentUserDesktop, CSIDL_DESKTOP, false);
        return currentUserDesktop.ToString();
      }
      // Or:
      static string YetAnotherGetDesktopPath()
      {
        Guid PublicDesktop = new Guid("C4AA340D-F20F-4863-AFEF-F87EF2E6BA25");
        IntPtr pPath;
        if (SHGetKnownFolderPath(PublicDesktop, 0, IntPtr.Zero, out pPath) == 0)
        {
          return System.Runtime.InteropServices.Marshal.PtrToStringUni(pPath);
        }
        return string.Empty;
      }
    }
