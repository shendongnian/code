    [DllImport("user32", SetLastError = true)]
        private static extern int SetCursorPos(int x, int y);
        public static void SetMousePos(Point p) {
            SetMousePos(p.X, p.Y);
        }
        public static void SetMousePos(int x, int y) {
            SetCursorPos(x, y);
        }
