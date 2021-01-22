using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CaptureScreenshots
{
    class Program
    {
        const int ENUM_CURRENT_SETTINGS = -1;
        static void Main(string[] args)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                DEVMODE dm = new DEVMODE();
                dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
                EnumDisplaySettings(screen.DeviceName, ENUM_CURRENT_SETTINGS, ref dm);
                using (Bitmap bmp = new Bitmap(dm.dmPelsWidth, dm.dmPelsHeight))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(dm.dmPositionX, dm.dmPositionY, 0, 0, bmp.Size);
                    bmp.Save(screen.DeviceName.Split('\\').Last() + ".png");
                }
            }
        }
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
    }
}
References:
https://stackoverflow.com/a/36864741/987968
http://pinvoke.net/default.aspx/user32/EnumDisplaySettings.html?diff=y
