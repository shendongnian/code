    public class VisibilityTester
    {
        private delegate bool CallBackPtr(int hwnd, int lParam);
        private static CallBackPtr callBackPtr;
        /// <summary>
        /// The enumerated pointers of actually visible windows
        /// </summary>
        public static List<IntPtr> enumedwindowPtrs = new List<IntPtr>();
        /// <summary>
        /// The enumerated rectangles of actually visible windows
        /// </summary>
        public static List<Rectangle> enumedwindowRects = new List<Rectangle>();
        /// <summary>
        /// Does a hit test for specified control (is point of control visible to user)
        /// </summary>
        /// <param name="ctrlRect">the rectangle (usually Bounds) of the control</param>
        /// <param name="ctrlHandle">the handle for the control</param>
        /// <param name="p">the point to test (usually MousePosition)</param>
        /// <param name="ExcludeWindow">a control or window to exclude from hit test (means point is visible through this window)</param>
        /// <returns>boolean value indicating if p is visible for ctrlRect</returns>
        public static bool HitTest(Rectangle ctrlRect, IntPtr ctrlHandle, Point p, IntPtr ExcludeWindow)
        {
            // clear results
            enumedwindowPtrs.Clear();
            enumedwindowRects.Clear();
            // Create callback and start enumeration
            callBackPtr = new CallBackPtr(EnumCallBack);
            EnumDesktopWindows(IntPtr.Zero, callBackPtr, 0);
            // Go from last to first window, and substract them from the ctrlRect area
            Region r = new Region(ctrlRect);
            bool StartClipping = false;
            for (int i = enumedwindowRects.Count - 1; i >= 0; i--)
            {
                if (StartClipping && enumedwindowPtrs[i] != ExcludeWindow)
                {
                    r.Exclude(enumedwindowRects[i]);
                }
                if (enumedwindowPtrs[i] == ctrlHandle) StartClipping = true;
            }
            // return boolean indicating if point is visible to clipped (truly visible) window
            return r.IsVisible(p);
        }
        /// <summary>
        /// Window enumeration callback
        /// </summary>
        private static bool EnumCallBack(int hwnd, int lParam)
        {
            // If window is visible and not minimized (isiconic)
            if (IsWindow((IntPtr)hwnd) && IsWindowVisible((IntPtr)hwnd) && !IsIconic((IntPtr)hwnd))
            { 
                // add the handle and windowrect to "found windows" collection
                enumedwindowPtrs.Add((IntPtr)hwnd);
                RECT rct;
                if (GetWindowRect((IntPtr)hwnd, out rct))
                {
                    // add rect to list
                    enumedwindowRects.Add(new Rectangle(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top));
                }
                else
                {
                    // invalid, make empty rectangle
                    enumedwindowRects.Add(new Rectangle(0, 0, 0, 0));
                }
            }
            return true;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern int EnumDesktopWindows(IntPtr hDesktop, CallBackPtr callPtr, int lPar);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
            public override string ToString()
            {
                return Left + "," + Top + "," + Right + "," + Bottom;
            }
        }
    }
