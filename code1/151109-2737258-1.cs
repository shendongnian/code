    [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);
    
            public static void MoveCursorToPoint(int x, int y)
            {
                SetCursorPos(x, y);
            }
