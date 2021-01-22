    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
     
    private static void RegisterForFileExtension(string extension, string applicationPath)
        {
            RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + extension);
            FileReg.CreateSubKey("shell\\open\\command").SetValue("", applicationPath + " %1");
            FileReg.Close();
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
