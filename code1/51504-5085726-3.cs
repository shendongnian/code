    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    class Program
    {
      // 1st way
      private const int MAX_PATH = 260;
      private const int CSIDL_DESKTOP = 0x0000;
      private const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019; // Can get to All Users desktop even on .NET 2.0,
                                                                // where Environment.SpecialFolder.CommonDesktopDirectory is not available
      [DllImport("shell32.dll")]
      private static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, int nFolder, bool fCreate);
      static string GetDesktopPath()
      {
        StringBuilder currentUserDesktop = new StringBuilder(MAX_PATH);
        SHGetSpecialFolderPath((IntPtr)0, currentUserDesktop, CSIDL_DESKTOP, false);
        return currentUserDesktop.ToString();
      }
      // 2nd way
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
