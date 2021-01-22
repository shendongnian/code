    using System;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace PlatformDetection
    {
        internal partial class PInvoke
        {
            [DllImport("Coredll.dll", EntryPoint = "SystemParametersInfoW", CharSet = CharSet.Unicode)]
            static extern int SystemParametersInfo4Strings(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);
    
            public enum SystemParametersInfoActions : uint
            {
                SPI_GETPLATFORMTYPE = 257, // this is used elsewhere for Smartphone/PocketPC detection
                SPI_GETOEMINFO = 258,
            }
    
            public static string GetOemInfo()
            {
                StringBuilder oemInfo = new StringBuilder(50);
                if (SystemParametersInfo4Strings((uint)SystemParametersInfoActions.SPI_GETOEMINFO,
                    (uint)oemInfo.Capacity, oemInfo, 0) == 0)
                    throw new Exception("Error getting OEM info.");
                return oemInfo.ToString();
            }
    
        }
        internal partial class PlatformDetection
        {
            private const string MicrosoftEmulatorOemValue = "Microsoft DeviceEmulator";
            public static bool IsEmulator()
            {
                return PInvoke.GetOemInfo() == MicrosoftEmulatorOemValue;
            }
        }
        class EmulatorProgram
        {
            static void Main(string[] args)
            {
                MessageBox.Show("Emulator: " + (PlatformDetection.IsEmulator() ? "Yes" : "No"));
            }
        }
    }
