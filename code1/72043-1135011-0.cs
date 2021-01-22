        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Rectangle
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }
        private static void Click(IntPtr Handle)
        {
            lock (typeof(MouseAction))
            {
                Rectangle buttonDesign;
                GetWindowRect(Handle, out buttonDesign);
                Random r = new Random();
                int curX = 10 + buttonDesign.X + r.Next(100 - 20);
                int curY = 10 + buttonDesign.Y + r.Next(60 - 20);
                SetCursorPos(curX, curY);
                //Mouse Right Down and Mouse Right Up
                mouse_event((uint)MouseEventFlags.LEFTDOWN, curX, curY, 0, 0);
                mouse_event((uint)MouseEventFlags.LEFTUP, curX, curY, 0, 0);  
            }
        }
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(
            long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect); 
