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
    }
