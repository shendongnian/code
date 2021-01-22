        using System;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
        
        namespace SystrayUtil
        {
            internal enum MessageEnum
            {
                WM_MOUSEMOVE = 0x0200,
                WM_CLOSE = 0x0010,
            }
        
            internal struct RECT
            {
                internal int Left;
                internal int Top;
                internal int Right;
                internal int Bottom;
        
                internal RECT(int left, int top, int right, int bottom)
                {
                    Left = left;
                    Top = top;
                    Right = right;
                    Bottom = bottom;
                }
            }
        
            public sealed class Systray
            {
                [DllImport("user32.dll", SetLastError = true)]
                private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
                [DllImport("user32.dll", SetLastError = true)]
                private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, IntPtr lpszWindow);
        
                [DllImport("user32.dll", SetLastError = true)]
                private static extern IntPtr SendMessage(IntPtr hWnd, int message, uint wParam, long lParam);
        
                [DllImport("user32.dll", SetLastError = true)]
                private static extern bool GetClientRect(IntPtr hWnd, out RECT usrTray);
        
                public static void Cleanup()
                {
                    RECT sysTrayRect = new RECT();
                    IntPtr sysTrayHandle = FindWindow("Shell_TrayWnd", null);
                    if (sysTrayHandle != IntPtr.Zero)
                    {
                        IntPtr childHandle = FindWindowEx(sysTrayHandle, IntPtr.Zero, "TrayNotifyWnd", IntPtr.Zero);
                        if (childHandle != IntPtr.Zero)
                        {
                            childHandle = FindWindowEx(childHandle, IntPtr.Zero, "SysPager", IntPtr.Zero);
                            if (childHandle != IntPtr.Zero)
                            {
                                childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ToolbarWindow32", IntPtr.Zero);
                                if (childHandle != IntPtr.Zero)
                                {
                                    bool systrayWindowFound = GetClientRect(childHandle, out sysTrayRect);
                                    if (systrayWindowFound)
                                    {
                                        for (int x = 0; x < sysTrayRect.Right; x += 5)
                                        {
                                            for (int y = 0; y < sysTrayRect.Bottom; y += 5)
                                            {
                                                SendMessage(childHandle, (int)MessageEnum.WM_MOUSEMOVE, 0, (y << 16) + x);
                                            }
                                        }
                                    }
                                }
                            }
                        } 
                    }
                }
            }
        }
