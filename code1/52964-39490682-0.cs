    using System;
    using System.Runtime.InteropServices;
    namespace Win32
    {
        public static class HwndHelper
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
            public static bool GetWindowZOrder(IntPtr hwnd, out int zOrder)
            {
                const uint GW_HWNDPREV = 3;
                const uint GW_HWNDLAST = 1;
                var lowestHwnd = GetWindow(hwnd, GW_HWNDLAST);
                var z = 0;
                var hwndTmp = lowestHwnd;
                while (hwndTmp != IntPtr.Zero)
                {
                    if (hwnd == hwndTmp)
                    {
                        zOrder = z;
                        return true;
                    }
                    hwndTmp = GetWindow(hwndTmp, GW_HWNDPREV);
                    z++;
                }
                zOrder = int.MinValue;
                return false;
            }
        }
    }
