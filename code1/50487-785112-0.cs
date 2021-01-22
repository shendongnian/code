    public class DesktopHelper
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        /// <summary>
        /// Shows the desktop.
        /// </summary>
        public static void ShowDesktop()
        {
            keybd_event(0x5B, 0, 0, 0);
            keybd_event(0x4D, 0, 0, 0);
            keybd_event(0x5B, 0, 0x2, 0);
        }
    }
